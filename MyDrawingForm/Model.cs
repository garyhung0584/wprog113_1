using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public class Model
    {

        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();

        internal Shapes shapes = new Shapes();
        private string _mode = "";



        double _firstPointX;
        double _firstPointY;
        double _lastPointX;
        double _lastPointY;
        bool _isPressed = false;


        public void AddShape(string shape, string name, float x, float y, float height, float width)
        {
            shapes.CreateShape(shape, name, x, y, height, width);
            SetDrawingMode("");
            NotifyModelChanged();
        }


        public void PointerPressed(double x, double y)
        {
            if (_mode == "")
            {
                return;
            }
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
        }
        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _lastPointX = x;
                _lastPointY = y;
                NotifyModelChanged();
            }
        }
        public void PointerReleased(double x, double y)
        {
            if (_mode == "")
            {
                return;
            }
            if (_isPressed)
            {
                _isPressed = false;
                float width = (float)(_lastPointY - _firstPointY);
                float height = (float)(_lastPointX - _firstPointX);
                AddShape(GetDrawingMode(), GenerateRandomString(5), (float)_firstPointX, (float)_firstPointY, height, width);

                NotifyModelChanged();
            }
        }
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in shapes.GetShapes())
            {
                shape.Draw(graphics);
            }
            //if (_isPressed)
            //{
            //    Start.Draw
            //}
        }
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public void SetDrawingMode(string shape)
        {
            _mode = shape;
            NotifyModelChanged();
        }
        public string GetDrawingMode()
        {
            return _mode;
        }

        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }
    }
}
