using System;
using System.Drawing;

namespace DLLibs.Vectors
{
    internal class Vector
    {
        public Point EndPoint;
        public bool  IsSelected;
        public Point StartPoint;

        public Vector(Point startPoint, Point endPoint) {
            StartPoint = startPoint;
            EndPoint   = endPoint;
            IsSelected = false;
        }

        public double IsInLine(Point point) {
            var t = ((point.X - StartPoint.X) * (EndPoint.X - StartPoint.X) +
                     (point.Y - StartPoint.Y) * (EndPoint.Y - StartPoint.Y)) /
                    (Math.Pow(EndPoint.X - StartPoint.X, 2) + Math.Pow(EndPoint.Y - StartPoint.Y, 2));
            if (t      < 0) t = 0;
            else if (t > 1) t = 1;

            return Math.Sqrt
                (
                 Math.Pow(StartPoint.X - point.X + (EndPoint.X - StartPoint.X) * t, 2) +
                 Math.Pow(StartPoint.Y - point.Y + (EndPoint.Y - StartPoint.Y) * t, 2)
                );
        }

        public bool StartPointPressed(Point point) {
            var epsilonStart = Math.Sqrt(Math.Pow(point.X - StartPoint.X, 2) + Math.Pow(point.Y - StartPoint.Y, 2));
            return epsilonStart <= 5;
        }

        public bool EndPointPressed(Point point) {
            var epsilonEnd = Math.Sqrt(Math.Pow(point.X - EndPoint.X, 2) + Math.Pow(point.Y - EndPoint.Y, 2));
            return epsilonEnd <= 5;
        }
    }
}