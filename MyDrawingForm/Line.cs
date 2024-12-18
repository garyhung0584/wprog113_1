using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Line
    {
        public Shape Shape1 { get; set; }
        public Shape Shape2 { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }

        public Line(Shape shape1, Shape shape2, int p1, int p2)
        {
            Shape1 = shape1;
            Shape2 = shape2;
            P1 = p1;
            P2 = p2;
        }

        public void Draw(IGraphics graphics)
        {
            (int x1, int y1) = GetCoordinates(Shape1, P1);
            (int x2, int y2) = GetCoordinates(Shape2, P2);
            graphics.DrawLine(x1, y1, x2, y2);
        }

        private (int, int) GetCoordinates(Shape shape, int point)
        {
            switch (point)
            {
                case 1:
                    return (shape.X + shape.Width / 2, shape.Y);
                case 2:
                    return (shape.X, shape.Y + shape.Height / 2);
                case 3:
                    return (shape.X + shape.Width / 2, shape.Y + shape.Height);
                default:
                    return (shape.X + shape.Width, shape.Y + shape.Height / 2);
            }
        }
    }
}
