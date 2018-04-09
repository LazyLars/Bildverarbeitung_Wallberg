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

        public static Bitmap LoadHistogramInImage(Bitmap bmpimg)
        {
            int[] histoArray = new int[256];
            Color pixCol;

            bmpimg = ImageToGrey(bmpimg);

            for (int x = 0; x < bmpimg.Height; x++)
            {
                for (int y = 0; y < bmpimg.Width; y++)
                {
                    pixCol = bmpimg.GetPixel(x, y);

                    histoArray[pixCol.B] = histoArray[pixCol.B] + 1;
                }
            }

            for (int i = 0; i < histoArray.Length; i++)
            {
                histoArray[i] = (int)Math.Round((double)(histoArray[i] / bmpimg.Height), MidpointRounding.AwayFromZero);
            }

            int calcWidth = (int)Math.Round((double)bmpimg.Width / histoArray.Length);
            int counterArray = 0;

            for (int x = 0; x < bmpimg.Width; x++)
            {
                for (int i = 0; i < calcWidth; i++)
                {
                    for (int y = bmpimg.Height; y >= (bmpimg.Height - histoArray[counterArray]); y--)
                    {
                        bmpimg.SetPixel((x+i), y-1, Color.Black);
                    }
                }
                counterArray++;
                x++;
            }

            return bmpimg;
        }

    }
}
