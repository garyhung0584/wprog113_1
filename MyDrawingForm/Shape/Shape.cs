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
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TextBiasX { get; set; }
        public int TextBiasY { get; set; }

        public Shape(string name, int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
        {
            ShapeName = name;
            ShapeId = id;
            ShapeText = text;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextBiasX = textBiasX;
            TextBiasY = textBiasY;
        }

        public abstract void Draw(IGraphics graphics);

        public abstract bool IsPointInShape(int x, int y);
        public abstract bool IsPointAtText(int x, int y);

        public void DrawBoundingBox(IGraphics graphics)
        {
            graphics.DrawBoundingBox(X - 1, Y - 1, Width + 2, Height + 2);
            graphics.DrawBoundingBox((X + Width / 3) + TextBiasX, (Y + Height / 3) + TextBiasY, (10 * ShapeText.Length), 20);
            graphics.DrawDot((X + Width / 3) + TextBiasX + (10 * ShapeText.Length) / 2 - 2, (Y + Height / 3) + TextBiasY - 5, 5, 5);
        }

        public void Normalize()
        {
            if (Width < 0)
            {
                Width = Width * -1;
                X = X - Width;
            }
            if (Height < 0)
            {
                Height = Height * -1;
                Y = Y - Height;
            }
        }
    }
}
