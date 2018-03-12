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

        public static Bitmap LoadHistogramInImage(Bitmap map)
        {
            int[] histoArray = new int[256];
            Color pixCol;

            map = ImageToGrey(map);

            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    pixCol = map.GetPixel(x, y);

                    histoArray[pixCol.B] = histoArray[pixCol.B] + 1;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                histoArray[i] = (int)Math.Round((double)(histoArray[i] * 100 / (map.Height * map.Width)), MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < histoArray.Length*3; i++)
            {
                for (int y = map.Height; y > (map.Height / 3) * 2 + (map.Height / 3); y--)
                {
                    if (y != (y - histoArray[i/3]))
                    {
                        map.SetPixel(i, y-1, Color.Red);
                    }
                }
                i = i + 3;
            }

            return map;
        }

    }
}
