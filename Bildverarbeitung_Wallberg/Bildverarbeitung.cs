using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bildverarbeitung_Wallberg
{
    public static class Bildverarbeitung
    {
        public static Bitmap Load_Image(string imgPath)
        {
            return new Bitmap(imgPath);
        }

        public static Bitmap ImageToGrey(Bitmap map)
        {
            Color pixCol;
            int sumCol;

            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    pixCol = map.GetPixel(x, y);
                    sumCol = (pixCol.R + pixCol.G + pixCol.B) / 3;

                    map.SetPixel(x, y, Color.FromArgb(sumCol, sumCol, sumCol));
                }
            }

            return map;
        }

        public static Bitmap LoadHistogramInImage(Bitmap bmpimg, bool GreyScale = true)
        {
            int[] histoArrayRed = new int[256];
            int[] histoArrayGreen = new int[256];
            int[] histoArrayBlue = new int[256];

            Color pixCol;

            if (GreyScale)
                bmpimg = ImageToGrey(bmpimg);

            for (int x = 0; x < bmpimg.Height; x++)
            {
                for (int y = 0; y < bmpimg.Width; y++)
                {
                    pixCol = bmpimg.GetPixel(x, y);

                    histoArrayRed[pixCol.R] = histoArrayRed[pixCol.R] + 1;
                    if (!GreyScale)
                    {
                        histoArrayGreen[pixCol.G] = histoArrayGreen[pixCol.G] + 1;
                        histoArrayBlue[pixCol.B] = histoArrayBlue[pixCol.B] + 1;
                    }
                }
            }

            for (int i = 0; i < histoArrayRed.Length; i++)
            {
                histoArrayRed[i] = (int)Math.Round((double)(histoArrayRed[i] / bmpimg.Height), MidpointRounding.AwayFromZero);
                if (!GreyScale)
                {
                    histoArrayGreen[i] = (int)Math.Round((double)(histoArrayGreen[i] / bmpimg.Height), MidpointRounding.AwayFromZero);
                    histoArrayBlue[i] = (int)Math.Round((double)(histoArrayBlue[i] / bmpimg.Height), MidpointRounding.AwayFromZero);
                }
            }

            int calcWidth = (int)Math.Round((double)bmpimg.Width / histoArrayRed.Length);
            int counterArray = 0;

            for (int x = 0; x < bmpimg.Width; x++)
            {
                if (histoArrayRed[counterArray] > histoArrayGreen[counterArray] && histoArrayRed[counterArray] > histoArrayBlue[counterArray])
                {
                    for (int i = 0; i < calcWidth; i++)
                    {
                        for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArrayRed[counterArray]); y--)
                        {
                            bmpimg.SetPixel((x + i), y - 1, Color.Red);
                        }
                    }
                }
                else if (histoArrayBlue[counterArray] > histoArrayGreen[counterArray] && histoArrayBlue[counterArray] > histoArrayRed[counterArray])
                {
                    for (int i = 0; i < calcWidth; i++)
                    {
                        for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArrayRed[counterArray]); y--)
                        {
                            bmpimg.SetPixel((x + i), y - 1, Color.Blue);
                        }
                    }
                }
                else if (histoArrayGreen[counterArray] > histoArrayBlue[counterArray] && histoArrayGreen[counterArray] > histoArrayRed[counterArray])
                {
                    for (int i = 0; i < calcWidth; i++)
                    {
                        for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArrayRed[counterArray]); y--)
                        {
                            bmpimg.SetPixel((x + i), y - 1, Color.Blue);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < calcWidth; i++)
                    {
                        for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArrayRed[counterArray]); y--)
                        {
                            bmpimg.SetPixel((x + i), y - 1, Color.Black);
                        }
                    }
                }


                counterArray++;
                x++;
            }

            return bmpimg;
        }

    }
}
