using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        readonly List<string> historyHashes = new List<string>();

        int born = 0;

        int dead = 0;

        int stillAlive = 0;

        int MinNeighbors = 2;

        int MaxNeighbors = 4;

        int NeighboursForNewLife = 3;

        int DeathPercent = 7;

        int MaxLife = 6;

        readonly int[,] lifeTime;

        bool changed = false;

        static bool suspended = true;

        static bool oneStep = false;

        static int chartPoints = 0;

        static int maxChartPoints = 0;

        static int maxAlive = 0;

        static int minAlive = 0;

        static int maxBorn = 0;

        static int minBorn = 0;

        static int maxDead = 0;

        static int minDead = 0;

        static bool seedComplete = false;

        readonly MainForm instance;

        static int fieldHeight = 0;

        static int fieldWidth = 0;

        static int moveCounter = 0;

        int densityPercent = 0;

        bool[,] currentState = new bool[fieldHeight, fieldWidth];

        private bool[,] nextState = new bool[fieldHeight, fieldWidth];

        readonly ImageController currentBitMap;

        int zoom = 1;

        private static CancellationTokenSource killAsync;

        Point lastPoint = Point.Empty;

        bool isMouseDown;

        bool isBusy = false;

        public MainForm()
        {
            InitializeComponent();

            instance = this;
            MaxLife = (int)countForMaxLife.Value;
            DeathPercent = (int)percentDeathCount.Value;
            fieldHeight = picture.Height;
            fieldWidth = picture.Width;
            lifeTime = new int[fieldHeight, fieldWidth];
            currentBitMap = new ImageController(fieldWidth, fieldHeight);
            ComboBoxForChart.SelectedIndex = 0;
            picture.MouseWheel += ZoomControl_MouseWheel;
            chartPoints = Convert.ToInt16(ComboBoxForChart.Items[0].ToString());
            ComboBoxForChart.SelectedIndexChanged += ChartComboBox_SelectedIndexChanged;
            maxChartPoints = Convert.ToInt32(ComboBoxForChart.Items[ComboBoxForChart.Items.Count - 1].ToString());

            Task.Run(() => {
                while (true)
                {
                    while (suspended)
                    {
                        Task.Delay(100);
                    }
                    try
                    {
                        DrawBitmap();
                        Transform();
                        CheckAndStoreHistoryHash();
                    }
                    catch (Exception ex)
                    {
                        instance.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show(instance, string.Format("Ошибка на шаге {0}: {1}{2}{3}", moveCounter, ex.Message,
                                Environment.NewLine, ex.InnerException?.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                    moveCounter++;
                    if (oneStep)
                    {
                        oneStep = false;
                        Suspend();
                    }
                }
            });
        }
        private void ZoomControl_MouseWheel(object sender, MouseEventArgs e)
        {
            instance.Invoke((MethodInvoker)delegate
            {
                bool show = false;
                if (e.Delta > 3)
                {
                    if (zoom < 5) zoom++;
                    if (suspended)
                    {
                        show = true;
                    }
                }
                if (e.Delta < -3)
                {
                    if (zoom > 1) zoom--;
                    if (suspended)
                    {
                        show = true;
                    }
                }
                if (show) ShowBitMap();
            });
        }

        private void ShowBitMap()
        {
            Size newSize = new Size((int)(currentBitMap.Width * zoom), (int)(currentBitMap.Height * zoom));
            Bitmap tmpbitmap = new Bitmap(currentBitMap.Bitmap, newSize);
            picture.Width = tmpbitmap.Width;
            picture.Height = tmpbitmap.Height;
            picture.Image = tmpbitmap;
            picture.Refresh();
            panel1.VerticalScroll.Visible = (picture.Height > panel1.Height);
            panel1.HorizontalScroll.Visible = (picture.Width > panel1.Width);
            zoomlabel.Text = string.Format("x{0}", zoom);
            Refresh();
        }
        private void InitialSeed()
        {
            int alive = 0;
            maxAlive = 0;
            minAlive = 0;
            if (currentState.Length == 0)
                currentState = new bool[fieldHeight, fieldWidth];
            if (densityPercent > 0)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                for (int y = 0; y < fieldHeight; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {
                        currentState[y, x] = (rnd.Next(100) <= densityPercent);
                        if (currentState[y, x])
                        {
                            alive++;
                            maxAlive++;
                            minAlive++;
                        }
                        lifeTime[y, x] = -1;
                    }
                }
            }
            else
            {
                currentState = new bool[fieldHeight, fieldWidth];
                for (int y = 0; y < fieldHeight; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {

                        lifeTime[y, x] = -1;
                    }
                }
            }
            maxBorn = 0;
            minBorn = 999999999;
            maxDead = 0;
            minDead = 999999999;
            moveCounter = 0;
            ShowCurrentStepInfo();
            DrawBitmap();
            if (densityPercent == 0)
            {
                RunButton.Enabled = false;
                RunOneStepButton.Enabled = false;
                ResetButton.Enabled = false;
                seedComplete = false;
            }
            else
            {
                if (!seedComplete)
                {
                    RunButton.Enabled = true;
                    RunOneStepButton.Enabled = true;
                    ResetButton.Enabled = true;
                    seedComplete = true;
                }
            }
        }
        private void ShowCurrentStepInfo()
        {
            instance.Invoke((MethodInvoker)delegate
            {
                movelabel.Text = string.Format("Ход № {0}", moveCounter);
                bornlabel.Text = string.Format("Родилось: {0} (Макс: {1}/Мин: {2})", born, maxBorn, minBorn);
                deadlabel.Text = string.Format("Умерло: {0} (Макс: {1}/Мин: {2})", dead, maxDead, minDead);
                alivelabel.Text = string.Format("Живы: {0} (Макс: {1}/Мин: {2})", stillAlive, maxAlive, minAlive);
                Refresh();
            });
        }
        private void Transform()
        {
            born = 0;
            dead = 0;
            stillAlive = 0;
            changed = false;
            nextState = new bool[fieldHeight, fieldWidth];

            int divider = fieldHeight / 2;

            killAsync = new CancellationTokenSource();


            var task1 = Task.Run(() => ProcessTransform(0, divider), killAsync.Token);
            var task2 = Task.Run(() => ProcessTransform(divider, fieldHeight), killAsync.Token);
            Task.WhenAll(task1, task2).Wait();

            instance.Invoke((MethodInvoker)delegate
            {
                if (stillAlive > maxAlive) maxAlive = stillAlive;
                if (stillAlive < minAlive) minAlive = stillAlive;
                if (born > maxBorn) maxBorn = born;
                if (born < minBorn) minBorn = born;
                if (dead > maxDead) maxDead = dead;
                if (dead < minDead) minDead = dead;

                ShowCurrentStepInfo();

                if (chart.Series[0].Points.Count > maxChartPoints)
                {
                    for (int i = 0; i < chart.Series[0].Points.Count - maxChartPoints; i++)
                    {
                        chart.Series[0].Points.RemoveAt(0);
                        chart.Series[1].Points.RemoveAt(0);
                        chart.Series[2].Points.RemoveAt(0);
                    }
                }

                chart.ChartAreas[0].AxisX.Minimum = (moveCounter <= chartPoints) ? 0 : (moveCounter - chartPoints);
                chart.ChartAreas[0].AxisX.Maximum = (moveCounter <= chartPoints) ? chartPoints : (chart.ChartAreas[0].AxisX.Minimum + chartPoints);

                chart.ChartAreas[0].AxisY.Minimum = (moveCounter <= chartPoints) ? Math.Floor(Math.Min(minAlive, Math.Min(minDead, minBorn)) * 0.5)
                : Math.Floor(Math.Min(chart.Series[1].Points.Reverse().Take(chartPoints).Reverse().Min(a => a.YValues[0]), chart.Series[2].Points.Reverse()
                .Take(chartPoints).Reverse().Min(b => b.YValues[0])) * 0.5);
                chart.ChartAreas[0].AxisY.Maximum = (moveCounter <= chartPoints) ? Math.Floor(Math.Max(maxAlive, Math.Max(maxDead, maxBorn)) * 1.1)
                : Math.Floor(chart.Series[0].Points.Reverse().Take(chartPoints).Reverse().Max(a => a.YValues[0]) * 1.1);

                chart.Series[0].Points.AddXY(moveCounter, stillAlive);
                chart.Series[1].Points.AddXY(moveCounter, born);
                chart.Series[2].Points.AddXY(moveCounter, dead);
            });
            if (changed)
                Array.Copy(nextState, currentState, nextState.Length);

        }
        private async Task<bool> ProcessTransform(int from, int to)
        {
            await Task.Run((Action)(() =>
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                for (int y = from; y < to; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {
                        int NeighboursCount = GetNeighbors(y, x);
                        bool state = currentState[y, x];
                        switch (state)
                        {
                            case true:
                                lifeTime[y, x]++;
                                stillAlive++;

                                var CurrentDeathPercent = DeathPercent > 0 ? DeathPercent * (MaxLife > 0 ? (0.5 + lifeTime[y, x]
                                / (2 * MaxLife)) : 1) * 1.00 : 0;


                                if (NeighboursCount > MaxNeighbors
                                || NeighboursCount < MinNeighbors
                                || (lifeTime[y, x] == MaxLife)
                                || (rnd.NextDouble() * 100 <= CurrentDeathPercent))
                                {
                                    dead++;
                                    stillAlive--;
                                    nextState[y, x] = false;
                                    lifeTime[y, x] = 0;
                                }
                                else
                                {
                                    nextState[y, x] = true;
                                }
                                break;

                            case false:
                                if (!state && NeighboursCount == this.NeighboursForNewLife)
                                {
                                    nextState[y, x] = true;
                                    born++;
                                    lifeTime[y, x] = 0;
                                }
                                else
                                {
                                    nextState[y, x] = false;
                                    lifeTime[y, x] = -1;
                                }
                                break;
                        }
                        changed |= currentState[y, x] != nextState[y, x];
                    }
                }
            }));
            return true;
        }
        private int GetNeighbors(int y, int x)
        {
            int res = 0;

            var Yinc = (y + 1) % fieldHeight;
            var Ydec = (fieldHeight + y - 1) % fieldHeight;
            var Xinc = (x + 1) % fieldWidth;
            var Xdec = (fieldWidth + x - 1) % fieldWidth;
            if (currentState[Yinc, Xdec]) res++;
            if (currentState[Yinc, (x)]) res++;
            if (currentState[Yinc, Xinc]) res++;
            if (currentState[(y), Xdec]) res++;
            if (currentState[(y), Xinc]) res++;
            if (currentState[Ydec, Xdec]) res++;
            if (currentState[Ydec, (x)]) res++;
            if (currentState[Ydec, Xinc]) res++;
            return res;
        }
        private void DrawBitmap()
        {
            instance.Invoke((MethodInvoker)delegate
            {
                for (int y = 0; y < currentBitMap.Height; y++)
                {
                    for (int x = 0; x < currentBitMap.Width; x++)
                    {
                        // Новорожденная - синий
                        // Взрослая - зеленый
                        // Умерла - красный
                        // Давно умерла - черный

                        currentBitMap.SetPixel(x, y,
                            currentState[y, x]
                            ? (lifeTime[y, x] == 0
                            ? Color.FromArgb(255, 0, 0, 255)
                            : Color.FromArgb(255, 0, 255, 0))
                            : (lifeTime[y, x] == 0
                            ? Color.FromArgb(255, 255, 0, 0)
                            : Color.FromArgb(255, 0, 0, 0)));
                    }
                }
                ShowBitMap();
            });
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void Pause_Click(object sender, EventArgs e)
        {
            Suspend();
        }
        private void Play()
        {
            instance.Invoke((MethodInvoker)delegate
            {
                PauseButton.Enabled = !oneStep;
                RunButton.Enabled = false;
                RunOneStepButton.Enabled = false;
                densityCount.Enabled = false;
                ResetButton.Enabled = false;
                suspended = false;
            });
        }
        private void Suspend()
        {
            instance.Invoke((MethodInvoker)delegate
            {
                PauseButton.Enabled = false;
                RunButton.Enabled = true;
                RunOneStepButton.Enabled = true;
                densityCount.Enabled = true;
                ResetButton.Enabled = true;
                suspended = true;
            });
        }
        private void MaxLifeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ClearChart();
            densityPercent = densityCount.Value;
            seedpercent.Text = densityPercent.ToString();
            currentState = new bool[fieldHeight, fieldWidth];
            nextState = new bool[fieldHeight, fieldWidth];
            InitialSeed();
        }

        private void ClearChart()
        {
            instance.Invoke((MethodInvoker)delegate
            {
                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
                chart.Series[2].Points.Clear();
            });
        }
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            oneStep = true;
            Play();
        }
        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartPoints = Convert.ToInt16(ComboBoxForChart.Text);
            instance.Invoke((MethodInvoker)delegate
            {
                chart.ChartAreas[0].AxisX.Minimum = (moveCounter <= chartPoints) ? 0 : (moveCounter - chart.Series[0].Points.Count);
                chart.ChartAreas[0].AxisX.Maximum = (moveCounter <= chartPoints) ? chartPoints : (chart.ChartAreas[0].AxisX.Minimum
                + chartPoints);
            });
        }

        private void DeathPercent_ValueChanged(object sender, EventArgs e)
        {
            DeathPercent = (int)percentDeathCount.Value;
        }
        private void MaxLife_ValueChanged(object sender, EventArgs e)
        {
            MaxLife = (int)countForMaxLife.Value;
        }
        private void MinNeighbours_ValueChanged(object sender, EventArgs e)
        {
            MinNeighbors = (int)countForMin.Value;
        }
        private void MaxNeighbours_ValueChanged(object sender, EventArgs e)
        {
            MaxNeighbors = (int)countForMax.Value;
        }
        private void NeighboursForNewLife_ValueChanged(object sender, EventArgs e)
        {
            NeighboursForNewLife = (int)countForNewLife.Value;
        }
        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (!suspended || zoom != 1 || isBusy)
                return;
            if (isMouseDown == true)
            {
                if (lastPoint != null)
                {
                    using (Graphics g = Graphics.FromImage(picture.Image))
                    {
                        g.DrawLine(new Pen(Color.FromArgb(255, 0, 255, 0), 1), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                    picture.Invalidate();
                    lastPoint = e.Location;
                }
            }
        }
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!suspended || zoom != 1 || isBusy)
                return;
            lastPoint = e.Location;
            isMouseDown = true;
        }
        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (!suspended || zoom != 1 || isBusy)
                return;
            isBusy = true;
            Task.Run(() =>
            {
                instance.Invoke((MethodInvoker)delegate
                {
                    var bm = (Bitmap)picture.Image;
                    isMouseDown = false;
                    lastPoint = Point.Empty;
                    for (int y = 0; y < picture.Height; y++)
                    {
                        for (int x = 0; x < picture.Width; x++)
                        {
                            currentState[y, x] = (bm.GetPixel(x, y) != Color.FromArgb(255, 0, 0, 0));
                        }
                    }
                    if (!RunButton.Enabled)
                    {
                        RunButton.Enabled = true;
                        RunOneStepButton.Enabled = true;
                        ResetButton.Enabled = true;
                    }
                });
                isBusy = false;
            });
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitialSeed();
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            zoom = 1;
            ClearChart();
            InitialSeed();
            historyHashes.Clear();
        }
        private void CheckAndStoreHistoryHash()
        {
            if (historyHashes.Count == 10000)
                historyHashes.RemoveAt(0);
            byte[] tmparr;
            using (var memoryStream = new MemoryStream())
            {
                currentBitMap.Bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                tmparr = memoryStream.ToArray();
            }
            // Хеш-функция
            SHA256 shaM = new SHA256Managed();
            var HashedbytesString = Convert.ToBase64String(shaM.ComputeHash(tmparr));
            if (!historyHashes.Any(rec => rec == HashedbytesString))
            {
                historyHashes.Add(HashedbytesString);
            }
            else
            {
                var stepsBefore = historyHashes.Count - historyHashes.IndexOf(HashedbytesString);
                historyHashes.Clear();
                instance.Invoke((MethodInvoker)delegate
                {
                    killAsync.Cancel();
                    Pause_Click(null, null);
                    MessageBox.Show(instance, string.Format("Состояние поколения {0} повторяет состояние поколения назад: {1}", moveCounter, stepsBefore), "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
        }
    }
}
