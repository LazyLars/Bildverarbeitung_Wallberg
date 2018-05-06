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
                    map.SetPixel(x, y, Color.FromArgb(pixCol.A, sumCol, sumCol, sumCol));
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

            // converting the image to greyscale should be the job of the UI
            // we should not call other filters within our filters
            //if (GreyScale)
            //{
            //    bmpimg = ImageToGrey(bmpimg);
            //}

            for (int x = 0; x < bmpimg.Height; x++)
            {
                for (int y = 0; y < bmpimg.Width; y++)
                {
                    pixCol = bmpimg.GetPixel(x, y);

                    // key is the greyscale, value is the amount of pixels with that greyscale
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
                    Color histogrammColor = GreyScale == true ? Color.Black : Color.Red;
                    for (int i = 0; i < calcWidth; i++)
                    {
                        for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArrayRed[counterArray]); y--)
                        {
                            bmpimg.SetPixel((x + i), y - 1, histogrammColor);
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
                            bmpimg.SetPixel((x + i), y - 1, Color.Green);
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

        public static Bitmap LoadHistogramAreaInImage(Bitmap bmpimg)
        {
            int[] histoX = new int[bmpimg.Width];
            int[] histoY = new int[bmpimg.Height];

            bmpimg = ImageToGrey(bmpimg);

            Color pixCol;

            for (int x = 0; x < bmpimg.Width; x++)
            {
                int tempCounter = 0;
                for (int y = 0; y < bmpimg.Height; y++)
                {
                    pixCol = bmpimg.GetPixel(x, y);
                    tempCounter = tempCounter + pixCol.B;
                }
                histoX[x] = 255 - (tempCounter / bmpimg.Height);
            }

            for (int y = 0; y < bmpimg.Height; y++)
            {
                int tempCounter = 0;
                for (int x = 0; x < bmpimg.Width; x++)
                {
                    pixCol = bmpimg.GetPixel(x, y);
                    tempCounter = tempCounter + pixCol.B;
                }
                histoY[y] = 255 - (tempCounter / bmpimg.Width);
            }

            int maxY = (histoY.Max() / 5) * 4;
            int maxX = (histoX.Max() / 5) * 4;
            List<int> PositionMaxXList = new List<int>();
            List<int> PositionMaxYList = new List<int>();

            for (int i = 0; i < bmpimg.Width; i++)
            {
                if (maxX <= histoX[i])
                {
                    PositionMaxXList.Add(i);
                }

            }

            for (int i = 0; i < bmpimg.Height; i++)
            {
                if (maxY <= histoY[i])
                {
                    PositionMaxYList.Add(i);
                }
            }

            foreach (var x in PositionMaxXList)
            {
                foreach (var y in PositionMaxYList)
                {
                    bmpimg.SetPixel(x, y, Color.Red);
                }
            }

            int calcWidth = (int)Math.Round((double)bmpimg.Width / histoX.Length);

            int counterArray = 0;

            for (int x = 0; x < bmpimg.Width; x++)
            {
                for (int i = 0; i < calcWidth; i++)
                {
                    for (int y = bmpimg.Height; y >= (bmpimg.Height - histoX[counterArray]); y--)
                    {
                        bmpimg.SetPixel((x + i), y - 1, Color.Black);
                    }
                }
                counterArray++;
                //x++;
            }

            int calcHeight = (int)Math.Round((double)bmpimg.Height / histoY.Length);

            counterArray = 0;

            for (int y = 0; y < bmpimg.Height; y++)
            {
                for (int i = 0; i < calcHeight; i++)
                {
                    for (int x = bmpimg.Width; x >= (bmpimg.Width - histoY[counterArray]); x--)
                    {
                        bmpimg.SetPixel(x - 1, (y + i), Color.Black);
                    }
                }
                counterArray++;
                //y++;
            }

            return bmpimg;
        }

    }
}
