using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class DrawingState : IState
    {
        Model _m;

        Shape _hint;

        PointerState _pointerState;

        private static readonly Random random = new Random();
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private float _firstPointX;
        private float _firstPointY;
        private bool _isPressed = false;

        public DrawingState(PointerState pointerState)
        {
            this._pointerState = pointerState;
        }

        public void Initialize(Model m)
        {
            this._m = m;
            _isPressed = false;
            _hint = null;
        }

        public void MouseDown(float x, float y)
        {

            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
            _hint = _m.shapes.GetNewShape(_m.GetDrawingMode(), "", x, y, 0, 0);
        }

        public void MouseMove(float x, float y)
        {
            if (_isPressed && _hint != null)
            {
                _hint.Width = y - _firstPointY;
                _hint.Height = x - _firstPointX;
                _m.NotifyModelChanged();
            }
        }
        public void MouseUp(float x, float y)
        {
            _isPressed = false;
            if (_hint == null) return;

            _hint.Normalize();

            _m.AddShape(_m.GetDrawingMode(), GenerateRandomString(5), _hint.X, _hint.Y, _hint.Height, _hint.Width);
            _m.EnterPointerState();

            _pointerState.AddSelectedShape(_hint);
        }

        public void OnPaint(IGraphics graphics)
        {
            foreach (Shape shape in _m.GetShapes())
            {
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                _hint.Draw(graphics);
            }
        }


        public void KeyDown(int keyValue)
        {
            // do nothing
        }

        public void KeyUp(int keyValue)
        {
            // do nothing
        }

        public static string GenerateRandomString(int length)
        {
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
