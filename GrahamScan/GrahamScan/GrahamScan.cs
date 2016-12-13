using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahamScan
{
    public static class StackExtensions
    {
        public static Point NextToTop(this Stack<Point> source)
        {
            var top = source.Pop();
            var next = source.Peek();
            source.Push(top);
            return next;
        }
    }

    public static class PointExtensions
    {
        public static int Orientation(this Point root, Point q, Point r)
        {
            int val = (q.Y - root.Y) * (r.X - q.X) - (q.X - root.X) * (r.Y - q.Y);
            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        public static int DistanceTo(this Point source, Point target)
        {
            return (source.X - target.X) * (source.X - target.X) + (source.Y - target.Y) * (source.Y - target.Y);
        }
    }

    public class RootPointComparer : Comparer<Point>
    {
        private readonly Point Root;
        public RootPointComparer(Point root)
        {
            Root = root;
        }

        public override int Compare(Point x, Point y)
        {
            if (x == y)
            {
                return 0;
            }

            int o = Root.Orientation(x, y);
            if (o == 0)
                return (Root.DistanceTo(y) >= Root.DistanceTo(x)) ? -1 : 1;

            return (o == 2) ? -1 : 1;
        }
    }

    public static class GrahamScan
    {
        public static Stack<Point> Process(Point[] points)
        {
            if (points.Length < 3)
            {
                throw new Exception("Not enought points for convex hull");
            }

            var sorted = points.OrderBy(p => p.Y).ThenBy(p => p.X).ToArray();
            var leftDown = sorted.First();
            sorted = sorted.Skip(1).OrderBy(p => p, new RootPointComparer(leftDown)).ToArray();
            points = new[] { leftDown }.Concat(sorted).ToArray();

            var stack = new Stack<Point>();
            stack.Push(points[0]);
            stack.Push(points[1]);
            stack.Push(points[2]);

            for (int i = 3; i < points.Length; i++)
            {
                while (stack.NextToTop().Orientation(stack.Peek(), points[i]) != 2)
                {
                    stack.Pop();
                }
                stack.Push(points[i]);
            }

            return stack;
        }
    }

}
