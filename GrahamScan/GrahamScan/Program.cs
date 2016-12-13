using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrahamScan
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt")
                .Select(p => p.Split(','))
                .Select(p => new Point(int.Parse(p[0]), int.Parse(p[1])))
                .ToArray();

            var output = GrahamScan.Process(input);

            File.WriteAllLines("output.txt", output.Select(p => String.Format("{0},{1}", p.X, p.Y)));

            var width = input.Max(p => p.X) + 100;
            var height = input.Max(p => p.Y) + 100;

            using (var bitmap = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
                    g.DrawLines(Pens.Red, output.Select(p => new Point(p.X + 50, p.Y + 50)).ToArray());
                }

                foreach (var pixel in input)
                {
                    bitmap.SetPixel(pixel.X + 50, pixel.Y + 50, Color.Green);
                }

                bitmap.Save("output.bmp");
            }

        }
    }
}
