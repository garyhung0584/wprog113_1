using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public abstract class Shape
    {
        public string ShapeName { get; set; }
        public int ShapeId { get; set; }
        public string ShapeText { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Shape(string name, int id, string text, float x, float y, float height, float width)
        {
            ShapeName = name;
            ShapeId = id;
            ShapeText = text;
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public abstract void Draw(IGraphics graphics);
    }

}
