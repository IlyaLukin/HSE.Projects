﻿using System.Drawing;
using Lab._2.Paint.Interfaces.UIInt;

namespace Lab._2.Paint.Module.DrawingTools.Tools
{
    internal class Ellipse : DrawingTool
    {
        private PointF point;
        public Ellipse(Pen paintbrush, bool isDash) : base(paintbrush, isDash) { }

        public override void PreShowing(ICanvas canvas, PointF _point) {
            point = _point;
            canvas.ExecuteChanging();
        }

        public override void PrepareToDrawing(ICanvas canvas, PointF point) {
            OldPoint = point;
            IsDrawing = true;
        }

        public override void Draw(ICanvas canvas, PointF point) {
            if (!IsDrawing) return;

            var graphics = GetGraphics(canvas.ShowedPicture);

            if (OldPoint.X < point.X && OldPoint.Y < point.Y) {
                graphics.DrawEllipse(Paintbrush,
                    OldPoint.X,
                    OldPoint.Y,
                    point.X - OldPoint.X,
                    point.Y - OldPoint.Y);
                return;
            }

            if (OldPoint.X > point.X && OldPoint.Y > point.Y) {
                graphics.DrawEllipse(Paintbrush,
                    point.X,
                    point.Y,
                    OldPoint.X - point.X,
                    OldPoint.Y - point.Y);
                return;
            }

            if (OldPoint.X < point.X && OldPoint.Y > point.Y) {
                graphics.DrawEllipse(Paintbrush,
                    OldPoint.X,
                    point.Y,
                    point.X - OldPoint.X,
                    OldPoint.Y - point.Y);
                return;
            }

            graphics.DrawEllipse(Paintbrush,
                point.X,
                OldPoint.Y,
                OldPoint.X - point.X,
                point.Y - OldPoint.Y);
            return;

            graphics.Dispose();
            canvas.ExecuteChanging();
        }

        public override void EndDrawing(ICanvas canvas, PointF point) {
            IsDrawing = false;
        }

        public override void PreShowDrawing(ICanvas canvas, Graphics preShowGraphics) {
            if (!IsDrawing) return;

            if (OldPoint.X < point.X && OldPoint.Y < point.Y) {
                preShowGraphics.DrawEllipse(Paintbrush,
                    OldPoint.X,
                    OldPoint.Y,
                    point.X - OldPoint.X,
                    point.Y - OldPoint.Y);
                return;
            }

            if (OldPoint.X > point.X && OldPoint.Y > point.Y) {
                preShowGraphics.DrawEllipse(Paintbrush,
                    point.X,
                    point.Y,
                    OldPoint.X - point.X,
                    OldPoint.Y - point.Y);
                return;
            }

            if (OldPoint.X < point.X && OldPoint.Y > point.Y)
                preShowGraphics.DrawEllipse(Paintbrush,
                    OldPoint.X,
                    point.Y,
                    point.X - OldPoint.X,
                    OldPoint.Y - point.Y);
            else
                preShowGraphics.DrawEllipse(Paintbrush,
                    point.X,
                    OldPoint.Y,
                    OldPoint.X - point.X,
                    point.Y - OldPoint.Y);
        }
    }
}