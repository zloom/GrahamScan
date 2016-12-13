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
        //static void Main(string[] args)
        //{
        //    var input = File.ReadLines("input.txt")
        //        .Select(p => p.Split(','))
        //        .Select(p => new Point(int.Parse(p[0]), int.Parse(p[1])))
        //        .ToArray();

        //    var output = GrahamScan.Process(input);

        //    File.WriteAllLines("output.txt", output.Select(p => String.Format("{0},{1}", p.X, p.Y)));

        //    var width = input.Max(p => p.X) + 100;
        //    var height = input.Max(p => p.Y) + 100;

        //    using (var bitmap = new Bitmap(width, height))
        //    {
        //        using (var g = Graphics.FromImage(bitmap))
        //        {
        //            g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
        //            g.DrawLines(Pens.Red, output.Select(p => new Point(p.X + 50, p.Y + 50)).ToArray());
        //        }

        //        foreach (var pixel in input)
        //        {
        //            bitmap.SetPixel(pixel.X + 50, pixel.Y + 50, Color.Green);
        //        }

        //        bitmap.Save("output.bmp");
        //    }

        //}


        static void Main(string[] args)
        {
            var rnd = new Random();

            var i = 0;
            while (true)
            {
                i++;
                var data = Enumerable.Range(0, 4)
                    .Select(p => new Point(rnd.Next(0, 10), rnd.Next(0, 10)))
                    .ToArray();               

                try
                {
                    GrahamScan.Process(data);
                }
                catch (Exception ex)
                {

                    var width = data.Max(p => p.X) + 100;
                    var height = data.Max(p => p.Y) + 100;

                    using (var bitmap = new Bitmap(width, height))
                    {
                        using (var g = Graphics.FromImage(bitmap))
                        {
                            g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));                           
                        }

                        foreach (var pixel in data)
                        {
                            bitmap.SetPixel(pixel.X + 50, pixel.Y + 50, Color.Green);
                        }

                        bitmap.Save(i + "-output.bmp");
                    }
                   
                }
            }

        }
    }
}
