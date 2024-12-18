using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MyDrawingForm
{
    internal class DrawingState : IState
    {
        Model _m;

        Shape _hint;

        PointerState _pointerState;

        private static readonly Random random = new Random();
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private int _firstPointX;
        private int _firstPointY;
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

        public void MouseDown(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
            _hint = _m.GetShape(_m.GetDrawingMode(), "", x, y, 0, 0);
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed)
            {
                int newWidth = x - _firstPointX;
                int newHeight = y - _firstPointY;

                if (newWidth < 0)
                {
                    _hint.X = x;
                    _hint.Width = -newWidth;
                }
                else
                {
                    _hint.X = _firstPointX;
                    _hint.Width = newWidth;
                }

                if (newHeight < 0)
                {
                    _hint.Y = y;
                    _hint.Height = -newHeight;
                }
                else
                {
                    _hint.Y = _firstPointY;
                    _hint.Height = newHeight;
                }

                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(int x, int y)
        {
            _isPressed = false;
            if (_hint == null) return;

            _hint.Normalize();
            _hint.ShapeText = GenerateRandomString(5);
            _m.commandManager.Execute(new DrawCommand(_m, _hint));

            _m.EnterPointerState();

            _pointerState.selectedShape = _hint;
            _m.NotifyModelChanged();
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
            foreach(Line line in _m.GetLines())
            {
                line.Draw(graphics);
            }
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

