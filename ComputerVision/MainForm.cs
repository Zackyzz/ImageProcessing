using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;

namespace ComputerVision
{
    public partial class MainForm : Form
    {
        private string sSourceFileName = "";
        private FastImage workImage;
        private Bitmap image = null;
        private FastImage workImage2;
        private Bitmap image2 = null;

        public MainForm()
        {
            InitializeComponent();
        }
        private int squaree(int n)
        {
            return n * n;
        }
        private double makeSum(double[] arr, int pos)
        {
            return pos == 0 ? arr[0] * arr[0] : arr[pos] * arr[pos] + makeSum(arr, pos - 1);
        }
        private int normalize(int n)
        {
            return n < 0 ? 0 : n > 255 ? 255 : n;
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            sSourceFileName = openFileDialog.FileName;
            panelSource.BackgroundImage = new Bitmap(sSourceFileName);
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
        }
        //grayscaling
        private void buttonGrayscale_Click(object sender, EventArgs e)
        {
            Color color;
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int average = (int)(0.299 * color.R + 0.587 * color.G + 0.144 * color.B);
                    color = Color.FromArgb(normalize(average), normalize(average), normalize(average));
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //negativare
        private void buttonNegativate_Click(object sender, EventArgs e)
        {
            Color color;
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    color = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //luminozitate
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            int delta = trackLuminosity.Value;
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    int R = workImage.GetPixel(i, j).R;
                    int G = workImage.GetPixel(i, j).G;
                    int B = workImage.GetPixel(i, j).B;
                    Color color = Color.FromArgb(normalize(R + delta), normalize(G + delta), normalize(B + delta));
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //contrast
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);

            int delta = trackContrast.Value;
            int minR = 255, minG = 255, minB = 255;
            int maxR = 0, maxG = 0, maxB = 0;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    if (R < minR) minR = R;
                    if (G < minG) minG = G;
                    if (B < minB) minB = B;

                    if (R > maxR) maxR = R;
                    if (G > maxG) maxG = G;
                    if (B > maxB) maxB = B;
                }
            }
            int aR = minR - delta;
            int bR = maxR + delta;
            int aG = minG - delta;
            int bG = maxG + delta;
            int aB = minB - delta;
            int bB = maxB + delta;

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    R = (R - minR) * (bR - aR) / (maxR - minR) + aR;
                    G = (G - minG) * (bG - aG) / (maxG - minG) + aG;
                    B = (B - minB) * (bB - aB) / (maxB - minB) + aB;

                    color = Color.FromArgb(normalize(R), normalize(G), normalize(G));
                    workImage.SetPixel(i, j, Color.FromArgb(normalize(R), normalize(G), normalize(G)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //egalizarea histogramei
        private void button1_Click(object sender, EventArgs e)
        {
            int[] hist = new int[256];
            int[] histc = new int[256];
            int[] transf = new int[256];

            Color color;
            workImage.Lock();

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;
                    int avg = (R + G + B) / 3;
                    hist[avg]++;
                }
            }

            histc[0] = hist[0];
            for (int i = 1; i <= 255; i++)
            {
                histc[i] = histc[i - 1] + hist[i];
            }

            for (int i = 0; i <= 255; i++)
            {
                transf[i] = (histc[i] * 255) / (workImage.Width * workImage.Height);
            }

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;
                    int avg = (R + G + B) / 3;

                    color = Color.FromArgb(transf[avg], transf[avg], transf[avg]);
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //miscorare
        private void smalling_Click(object sender, EventArgs e)
        {
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage.Lock();
            workImage2.Lock();

            for (int i = 0, a = 0; i < workImage.Width; i += 2, a++)
            {
                for (int j = 0, b = 0; j < workImage.Height; j += 2, b++)
                {
                    Color color = workImage.GetPixel(i, j);
                    workImage2.SetPixel(a, b, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage2.Unlock();
            workImage.Unlock();
        }
        //rotire
        private void button2_Click(object sender, EventArgs e)
        {
            Color color;
            int n = int.Parse(rotBox.Text);
            double x0 = workImage.Width / 2;
            double y0 = workImage.Height / 2;
            double t = n * Math.PI / 180;
            bool[,] boolPoints = new bool[workImage.Width, workImage.Height];

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage.Lock();
            workImage2.Lock();

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);

                    double x2 = Math.Cos(t) * (i - x0) - Math.Sin(t) * (j - y0) + x0;
                    double y2 = Math.Sin(t) * (i - x0) + Math.Cos(t) * (j - y0) + y0;

                    if (x2 >= 0 && x2 < workImage.Width && y2 >= 0 && y2 < workImage.Height)
                    {
                        workImage2.SetPixel((int)x2, (int)y2, color);
                        boolPoints[(int)x2, (int)y2] = true;
                    }
                }
            }
            for (int i = 1; i < workImage2.Width - 1; i++)
            {
                for (int j = 1; j < workImage2.Height - 1; j++)
                {
                    if (!boolPoints[i, j])
                    {
                        if (boolPoints[i, j - 1])
                        {
                            color = workImage2.GetPixel(i, j - 1);
                            workImage2.SetPixel(i, j, color);
                        }
                        else if (boolPoints[i, j + 1])
                        {
                            color = workImage2.GetPixel(i, j + 1);
                            workImage2.SetPixel(i, j, color);
                        }
                        else if (boolPoints[i - 1, j])
                        {
                            color = workImage2.GetPixel(i - 1, j);
                            workImage2.SetPixel(i, j, color);
                        }
                        else if (boolPoints[i + 1, j])
                        {
                            color = workImage2.GetPixel(i - 1, j);
                            workImage2.SetPixel(i, j, color);
                        }
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage2.Unlock();
            workImage.Unlock();
        }
        //filtru trece jos
        private void ftj_Click(object sender, EventArgs e)
        {
            int n = int.Parse(ftjBox.Text);
            int[,] H = new int[3, 3] { { 1, n, 1 }, { n, n * n, n }, { 1, n, 1 } };
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int redSum = 0, greenSum = 0, blueSum = 0;
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            redSum += workImage.GetPixel(a, b).R * H[a - i + 1, b - j + 1];
                            greenSum += workImage.GetPixel(a, b).G * H[a - i + 1, b - j + 1];
                            blueSum += workImage.GetPixel(a, b).B * H[a - i + 1, b - j + 1];
                        }
                    }
                    Color color = Color.FromArgb(redSum / squaree(n + 2), greenSum / squaree(n + 2), blueSum / squaree(n + 2));
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //filtru Markov imbunatatit
        public bool SaltAndPepper(int a, int b)
        {
            Color color = workImage.GetPixel(a, b);
            int avg = (color.R + color.G + color.B) / 3;
            return (avg == 0 || avg == 255) ? true : false;
        }
        public int SAD(int x1, int y1, int x2, int y2, int CS)
        {
            int S = 0;
            for (int j = -CS / 2; j <= CS / 2; j++)
            {
                if (j + y1 < workImage.Height && j + y1 >= 0 && j + y2 < workImage.Height && j + y2 >= 0)
                {
                    if (j == 0) continue;
                    else
                    {
                        Color color1 = workImage.GetPixel(x1, j + y1);
                        int avg1 = (color1.R + color1.G + color1.B) / 3;
                        Color color2 = workImage.GetPixel(x2, j + y2);
                        int avg2 = (color2.R + color2.G + color2.B) / 3;
                        S += Math.Abs(avg1 - avg2);
                    }
                }
            }
            for (int i = -CS / 2; i <= CS / 2; i++)
            {
                if (i + x1 < workImage.Width && i + x1 >= 0 && i + x2 < workImage.Width && i + x2 >= 0)
                {
                    if (i == 0) continue;
                    else
                    {
                        Color color1 = workImage.GetPixel(i + x1, y1);
                        int avg1 = (color1.R + color1.G + color1.B) / 3;
                        Color color2 = workImage.GetPixel(i + x2, y2);
                        int avg2 = (color2.R + color2.G + color2.B) / 3;
                        S += Math.Abs(avg1 - avg2);
                    }
                }
            }
            return S;
        }
        public int Markov(int x, int y, int CS, int SR, int T)
        {
            int[] Q = new int[256];
            for (int j = y - SR; j <= y + SR; j++)
            {
                if (j >= 0 && j < workImage.Height)
                {
                    if (j == y) continue;
                    if (SAD(x, y, x, j, CS) < T && !(SaltAndPepper(x, j)))
                    {
                        Color color = workImage.GetPixel(x, j);
                        int avg = (color.R + color.G + color.B) / 3;
                        Q[avg]++;
                    }

                }
            }
            for (int i = x - SR; i <= x + SR; i++)
            {
                if (i >= 0 && i < workImage.Width)
                {
                    if (i == x) continue;
                    if (SAD(x, y, i, y, CS) < T && !(SaltAndPepper(i, y)))
                    {
                        Color color = workImage.GetPixel(i, y);
                        int avg = (color.R + color.G + color.B) / 3;
                        Q[avg]++;
                    }

                }
            }
            for (int k = -SR; k <= SR; k++)
            {
                if (x + k >= 0 && x + k < workImage.Width && y + k >= 0 && y + k < workImage.Height)
                {
                    if (k == 0) continue;
                    else
                    {
                        int i = x + k;
                        int j = y + k;
                        if (SAD(x, y, i, j, CS) < T && !(SaltAndPepper(i, j)))
                        {
                            Color color = workImage.GetPixel(i, j);
                            int avg = (color.R + color.G + color.B) / 3;
                            Q[avg]++;
                        }
                    }
                }
            }
            for (int k = -SR; k <= SR; k++)
            {
                if (x - k >= 0 && x + k < workImage.Width && y + k >= 0 && y + k < workImage.Height)
                {
                    if (k == 0) continue;
                    else
                    {
                        int i = x - k;
                        int j = y + k;
                        if (SAD(x, y, i, j, CS) < T && !(SaltAndPepper(i, j)))
                        {
                            Color color = workImage.GetPixel(i, j);
                            int avg = (color.R + color.G + color.B) / 3;
                            Q[avg]++;
                        }
                    }
                }
            }
            int maxIndex = Q.ToList().IndexOf(Q.Max());
            Color finalColor = workImage.GetPixel(x, y);
            int lastAvg = (finalColor.R + finalColor.G + finalColor.B) / 3;
            return Q[maxIndex] == 0 ? lastAvg : maxIndex;
        }
        private void btnMarkov_Click(object sender, EventArgs e)
        {
            workImage.Lock();
            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    if (SaltAndPepper(i, j))
                    {
                        int color = Markov(i, j, 3, 4, 300);
                        workImage.SetPixel(i, j, Color.FromArgb(color, color, color));
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //filtru median
        private void btnSort_Click(object sender, EventArgs e)
        {
            workImage.Lock();
            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int[] redX = new int[9];
                    int[] greenX = new int[9];
                    int[] blueX = new int[9];
                    int q = 0;
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            redX[q] = workImage.GetPixel(a, b).R;
                            greenX[q] = workImage.GetPixel(a, b).G;
                            blueX[q] = workImage.GetPixel(a, b).B;
                            q++;
                        }
                    }
                    redX = redX.OrderBy(x => x).ToArray();
                    greenX = greenX.OrderBy(x => x).ToArray();
                    blueX = blueX.OrderBy(x => x).ToArray();

                    Color color = Color.FromArgb(redX[4], greenX[4], blueX[4]);
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }
        //filtru trece sus
        private void btnFTS_Click(object sender, EventArgs e)
        {
            int[,] H = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int redSum = 0, greenSum = 0, blueSum = 0;
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            redSum += workImage.GetPixel(a, b).R * H[a - i + 1, b - j + 1];
                            greenSum += workImage.GetPixel(a, b).G * H[a - i + 1, b - j + 1];
                            blueSum += workImage.GetPixel(a, b).B * H[a - i + 1, b - j + 1];
                        }
                    }
                    Color color = Color.FromArgb(normalize(redSum), normalize(greenSum), normalize(blueSum));
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage2.Unlock();
            workImage.Unlock();
        }
        //unsharping
        private void btnUnsharp_Click(object sender, EventArgs e)
        {
            double c = 0.6;
            double c1 = c / (2 * c - 1);
            double c2 = (1 - c) / (2 * c - 1);
            int n = 1;
            int[,] H = new int[3, 3] { { 1, n, 1 }, { n, n * n, n }, { 1, n, 1 } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    double redSum = 0, greenSum = 0, blueSum = 0;
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            redSum += workImage.GetPixel(a, b).R * H[a - i + 1, b - j + 1];
                            greenSum += workImage.GetPixel(a, b).G * H[a - i + 1, b - j + 1];
                            blueSum += workImage.GetPixel(a, b).B * H[a - i + 1, b - j + 1];
                        }
                    }
                    int newR = (int)(c1 * workImage.GetPixel(i, j).R - c2 * redSum / squaree(n + 2));
                    int newG = (int)(c1 * workImage.GetPixel(i, j).G - c2 * greenSum / squaree(n + 2));
                    int newB = (int)(c1 * workImage.GetPixel(i, j).B - c2 * blueSum / squaree(n + 2));

                    workImage2.SetPixel(i, j, Color.FromArgb(normalize(newR), normalize(newG), normalize(newB)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        //detectie de contururi
        private void btnKirsch_Click(object sender, EventArgs e)
        {
            int[,,] H = new int[4, 3, 3]
                { { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } },
                { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } },
                { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } },
                { { 1, 1, 0 }, { 1, 0, -1 }, { 0, -1, -1 } } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int[] redX = new int[4], greenX = new int[4], blueX = new int[4];
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            for (int q = 0; q < 4; q++)
                            {
                                redX[q] += workImage.GetPixel(a, b).R * H[q, a - i + 1, b - j + 1];
                                greenX[q] += workImage.GetPixel(a, b).G * H[q, a - i + 1, b - j + 1];
                                blueX[q] += workImage.GetPixel(a, b).B * H[q, a - i + 1, b - j + 1];
                            }
                        }
                    }
                    workImage2.SetPixel(i, j, Color.FromArgb(normalize(redX.Max()), normalize(greenX.Max()), normalize(blueX.Max())));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage2.Unlock();
            workImage.Unlock();
        }
        private void btnRobi_Click(object sender, EventArgs e)
        {
            int[,,] PQ = new int[2, 2, 2] { { { -1, 0 }, { 0, 1 } }, { { 0, 1 }, { -1, 0 } } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int[] redX = new int[2], greenX = new int[2], blueX = new int[2];
                    for (int a = i; a <= i + 1; a++)
                    {
                        for (int b = j; b <= j + 1; b++)
                        {
                            for (int q = 0; q < 2; q++)
                            {
                                redX[q] += workImage.GetPixel(a, b).R * PQ[q, a - i, b - j];
                                greenX[q] += workImage.GetPixel(a, b).G * PQ[q, a - i, b - j];
                                blueX[q] += workImage.GetPixel(a, b).B * PQ[q, a - i, b - j];
                            }
                        }
                    }
                    int newR = 7 * (int)Math.Sqrt(squaree(redX[0]) + squaree(redX[1]));
                    int newG = 7 * (int)Math.Sqrt(squaree(greenX[0]) + squaree(greenX[1]));
                    int newB = 7 * (int)Math.Sqrt(squaree(blueX[0]) + squaree(blueX[1]));

                    workImage2.SetPixel(i, j, Color.FromArgb(normalize(newR), normalize(newG), normalize(newB)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        private void btnSobel_Click(object sender, EventArgs e)
        {
            int[,,] PQ = new int[2, 3, 3]
                { { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } },
                { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int[] redX = new int[2], greenX = new int[2], blueX = new int[2];
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            for (int q = 0; q < 2; q++)
                            {
                                redX[q] += workImage.GetPixel(a, b).R * PQ[q, a - i + 1, b - j + 1];
                                greenX[q] += workImage.GetPixel(a, b).G * PQ[q, a - i + 1, b - j + 1];
                                blueX[q] += workImage.GetPixel(a, b).B * PQ[q, a - i + 1, b - j + 1];
                            }
                        }
                    }
                    int newR = (int)Math.Sqrt(squaree(redX[0]) + squaree(redX[1]));
                    int newG = (int)Math.Sqrt(squaree(greenX[0]) + squaree(greenX[1]));
                    int newB = (int)Math.Sqrt(squaree(blueX[0]) + squaree(blueX[1]));

                    workImage2.SetPixel(i, j, Color.FromArgb(normalize(newR), normalize(newG), normalize(newB)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        private void btnFrei_Click(object sender, EventArgs e)
        {
            double[,,] F = new double[9, 3, 3]
                { { { 1, Math.Sqrt(2), 1 }, { 0, 0, 0 }, { -1, -Math.Sqrt(2), -1 } },
                { { 1, 0, -1 }, { Math.Sqrt(2), 0, -Math.Sqrt(2) }, { 1, 0, -1 } },
                { { 0, -1, Math.Sqrt(2) }, { 1, 0, -1 }, { -Math.Sqrt(2), 1, 0 } },
                { { Math.Sqrt(2), -1, 0 }, { -1, 0, 1 }, { 0, 1, -Math.Sqrt(2) } },
                { { 0, 1, 0 }, { -1, 0, -1 }, { 0, 1, 0 } },
                { { -1, 0, 1 }, { 0, 0, 0 }, { 1, 0, -1 } },
                { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } },
                { { -2, 1, -2 }, { 1, 4, 1 }, { -2, 1, -2 } },
                { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    double[] redX = new double[9], greenX = new double[9], blueX = new double[9];
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            for (int q = 0; q < 9; q++)
                            {
                                redX[q] += workImage.GetPixel(a, b).R * F[q, a - i + 1, b - j + 1];
                                greenX[q] += workImage.GetPixel(a, b).G * F[q, a - i + 1, b - j + 1];
                                blueX[q] += workImage.GetPixel(a, b).B * F[q, a - i + 1, b - j + 1];
                            }
                        }
                    }
                    redX[8] /= 9;
                    greenX[8] /= 9;
                    blueX[8] /= 9;

                    int newR = (int)(Math.Sqrt(makeSum(redX, 3) / makeSum(redX, 8)) * 255);
                    int newG = (int)(Math.Sqrt(makeSum(greenX, 3) / makeSum(greenX, 8)) * 255);
                    int newB = (int)(Math.Sqrt(makeSum(blueX, 3) / makeSum(blueX, 8)) * 255);
                    workImage2.SetPixel(i, j, Color.FromArgb(normalize(newR), normalize(newG), normalize(newB)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        //filtru Gabor
        double scale(int pozr, int pozc, double u)
        {
            return Math.Exp(-(pozr * pozr + pozc * pozc) / (2 * 0.66 * 0.66)) *
                Math.Sin(1.5 * (pozr * Math.Cos(u) + pozc * Math.Sin(u)));
        }
        private void btnGabor_Click(object sender, EventArgs e)
        {
            int[,,] PQ = new int[2, 3, 3] { { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } },
                                          { { -1, 0, 1 }, { -1,0,1 }, { -1, 0, 1 } } };

            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    int[] redX = new int[2], greenX = new int[2], blueX = new int[2];
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            for (int q = 0; q < 2; q++)
                            {
                                redX[q] += workImage.GetPixel(a, b).R * PQ[q, a - i + 1, b - j + 1];
                                greenX[q] += workImage.GetPixel(a, b).G * PQ[q, a - i + 1, b - j + 1];
                                blueX[q] += workImage.GetPixel(a, b).B * PQ[q, a - i + 1, b - j + 1];
                            }
                        }
                    }

                    double uR = redX[1] == 0 ? redX[0] >= 0 ? Math.PI : 0 : redX[1] >= 0 ?
                        Math.Atan(redX[0] / redX[1]) + Math.PI / 2 : Math.Atan(redX[0] / redX[1]) + 3 * Math.PI / 2;
                    double uG = greenX[1] == 0 ? greenX[0] >= 0 ? Math.PI : 0 : greenX[1] >= 0 ?
                        Math.Atan(greenX[0] / greenX[1]) + Math.PI / 2 : Math.Atan(greenX[0] / greenX[1]) + 3 * Math.PI / 2;
                    double uB = blueX[1] == 0 ? blueX[0] >= 0 ? Math.PI : 0 : blueX[1] >= 0 ?
                        Math.Atan(blueX[0] / blueX[1]) + Math.PI / 2 : Math.Atan(blueX[0] / blueX[1]) + 3 * Math.PI / 2;

                    double sumaR = 0, sumaG = 0, sumaB = 0;
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            sumaR += scale(a - i + 1, b - j + 1, uR) * workImage.GetPixel(a, b).R;
                            sumaG += scale(a - i + 1, b - j + 1, uG) * workImage.GetPixel(a, b).G;
                            sumaB += scale(a - i + 1, b - j + 1, uB) * workImage.GetPixel(a, b).B;
                        }
                    }
                    workImage2.SetPixel(i, j, Color.FromArgb(normalize((int)sumaR), normalize((int)sumaG), normalize((int)sumaB)));
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        //segmentare - region growing
        private void seq(object sender, MouseEventArgs e)
        {
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            Queue<Point> pointsuri = new Queue<Point>();
            bool[,] visited = new bool[workImage.Width, workImage.Height];
            int T = int.Parse(TBox.Text);
            int xp = e.X * workImage.Width / panelSource.Width;
            int yp = e.Y * workImage.Height / panelSource.Height;

            Color colorP = workImage.GetPixel(xp, yp);
            workImage2.SetPixel(xp, yp, colorP);
            visited[xp, yp] = true;
            pointsuri.Enqueue(new Point { X = xp, Y = yp });
            double S = (colorP.R + colorP.G + colorP.B) / 3;
            double C = 1;

            while (pointsuri.Count > 0)
            {
                Point actual = pointsuri.Dequeue();
                Point[] arr = new Point[4]
                {   new Point { X = actual.X - 1, Y = actual.Y },
                    new Point { X = actual.X, Y = actual.Y - 1 },
                    new Point { X = actual.X + 1, Y = actual.Y },
                    new Point { X = actual.X, Y = actual.Y + 1 } };

                for (int i = 0; i < 4; i++)
                {
                    if (arr[i].X >= 0 && arr[i].X < workImage.Width && arr[i].Y >= 0 && arr[i].Y < workImage.Height)
                    {
                        if (!visited[arr[i].X, arr[i].Y])
                        {
                            Color color = workImage.GetPixel(arr[i].X, arr[i].Y);
                            double grey = (color.R + color.G + color.B) / 3;
                            if (Math.Abs(grey - S / C) <= T)
                            {
                                workImage2.SetPixel(arr[i].X, arr[i].Y, color);
                                pointsuri.Enqueue(arr[i]);
                                visited[arr[i].X, arr[i].Y] = true;
                                S += grey;
                                C++;
                            }
                        }
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
        //tresholding
        private void btnThreshold_Click(object sender, EventArgs e)
        {
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();
            double avg = 0;
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    Color color = workImage.GetPixel(i, j);
                    avg += (color.R + color.G + color.B) / 3;
                }
            }
            avg /= workImage.Width * workImage.Height;

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    Color color = workImage.GetPixel(i, j);
                    if (avg > (color.R + color.G + color.B) / 3)
                    {
                        workImage2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        workImage2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        public double getAVGr(double x, double y, double w, double h)
        {
            double avgR = 0;
            for (double i = x; i < x + w; i++)
            {
                for (double j = y; j < y + h; j++)
                {
                    Color color = workImage.GetPixel((int)i, (int)j);
                    avgR += color.R;
                }
            }
            return avgR / (w * h);
        }
        public double getAVGg(double x, double y, double w, double h)
        {
            double avgG = 0;
            for (double i = x; i < x + w; i++)
            {
                for (double j = y; j < y + h; j++)
                {
                    Color color = workImage.GetPixel((int)i, (int)j);
                    avgG += color.G;
                }
            }
            return avgG / (w * h);
        }
        public double getAVGb(double x, double y, double w, double h)
        {
            double avgB = 0;
            for (double i = x; i < x + w; i++)
            {
                for (double j = y; j < y + h; j++)
                {
                    Color color = workImage.GetPixel((int)i, (int)j);
                    avgB += color.B;
                }
            }
            return avgB / (w * h);
        }

        private void btnATreshold_Click(object sender, EventArgs e)
        {
            int T = int.Parse(pragT.Text);
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
            workImage2.Lock();
            workImage.Lock();

            List<SaM> ProcessList = new List<SaM>();
            List<SaM> RegionList = new List<SaM>();

            double avgR = 0, avgG = 0, avgB = 0;
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    Color color = workImage.GetPixel(i, j);
                    avgR += color.R;
                    avgG += color.G;
                    avgB += color.B;
                }
            }
            avgR /= workImage.Width * workImage.Height;
            avgR /= workImage.Width * workImage.Height;
            avgR /= workImage.Width * workImage.Height;

            //double avgR = getAVGr(0, 0, workImage.Width, workImage.Height);
            //double avgG = getAVGg(0, 0, workImage.Width, workImage.Height);
            //double avgB = getAVGb(0, 0, workImage.Width, workImage.Height);

            ProcessList.Add(new SaM(0, 0, workImage.Height, workImage.Width, avgR, avgG, avgB));

            while (ProcessList.Count != 0)
            {
                double x = ProcessList[0].x;
                double y = ProcessList[0].y;
                double w = ProcessList[0].width;
                double h = ProcessList[0].height;

                double avgRi = getAVGr(x, y, w, h);
                double avgGi = getAVGg(x, y, w, h);
                double avgBi = getAVGb(x, y, w, h);

                if (x < 0 && y < 0 && x + w < workImage.Width && y + h < workImage.Height)
                {
                    double meanRegion = (avgRi + avgGi + avgBi) / 3;
                    double SD = 0;
                    for (double r = x; r < x + w; r++)
                    {
                        for (double c = y; c < y + h; c++)
                        {
                            Color color = workImage.GetPixel((int)r, (int)c);
                            SD += Math.Pow((color.R + color.G + color.B) / 3 - meanRegion, 2);
                        }
                    }
                    if (w * h > 1)
                    {
                        SD /= w * h - 1;
                    }

                    if (SD < T || (w == 1 || h == 1))
                    {
                        RegionList.Add(ProcessList[0]);
                        ProcessList.Remove(ProcessList[0]);
                    }
                    else
                    {
                        double w2 = w / 2;
                        double h2 = h / 2;

                        double avgR1 = getAVGr(x, y, h2, w2);
                        double avgG1 = getAVGg(x, y, h2, w2);
                        double avgB1 = getAVGb(x, y, h2, w2);

                        double avgR2 = getAVGr(x + w2, y, w2, h2);
                        double avgG2 = getAVGg(x + w2, y, w2, h2);
                        double avgB2 = getAVGb(x + w2, y, w2, h2);

                        double avgR3 = getAVGr(x, y + h2, w2, h2);
                        double avgG3 = getAVGg(x, y + h2, w2, h2);
                        double avgB3 = getAVGb(x, y + h2, w2, h2);

                        double avgR4 = getAVGr(x + w2, y + h2, w2, h2);
                        double avgG4 = getAVGg(x + w2, y + h2, w2, h2);
                        double avgB4 = getAVGb(x + w2, y + h2, w2, h2);

                        ProcessList.Add(new SaM(x, y, h2, w2, avgR1, avgG1, avgB1));
                        ProcessList.Add(new SaM(x + w2, y, w2, h2, avgR2, avgG2, avgB2));
                        ProcessList.Add(new SaM(x, y + h2, w2, h2, avgR3, avgG3, avgB3));
                        ProcessList.Add(new SaM(x + w2, y + h2, w2, h2, avgR4, avgG4, avgB4));

                        ProcessList.Remove(ProcessList[0]);
                    }
                }
            }
            for (int q = 0; q < RegionList.Count; q++)
            {
                for (int i = (int)RegionList[q].x; i < (int)RegionList[q].x + RegionList[q].width; i++)
                {
                    for (int j = (int)RegionList[q].y; j < (int)RegionList[q].y + RegionList[q].height; j++)
                    {
                        workImage2.SetPixel(i, j,
                            Color.FromArgb((int)RegionList[i].avgR, (int)RegionList[i].avgG, (int)RegionList[i].avgB));
                    }
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }
    }
}
