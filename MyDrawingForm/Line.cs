using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class Line
    {
        public Shape Shape1 { get; set; }
        public Shape Shape2 { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }

        public Line(Shape shape1, Shape shape2, int p1, int p2) {
            Shape1 = shape1;
            Shape2 = shape2;
            P1 = p1;
            P2 = p2;
        }

        //public void Draw(IGraphics graphics)
        //{
        //    int start = P1.X;
        //}
    }
}
