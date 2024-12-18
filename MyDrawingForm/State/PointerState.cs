using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyDrawingForm
{
    internal class PointerState : IState
    {
        private Model _m;

        // 紀錄選取的圖
        public Shape selectedShape;

        private int _prevPointX;
        private int _prevPointY;
        private bool _isPressed = false;
        private bool _isDotPressed = false;

        public void Initialize(Model m)
        {
            this._m = m ?? throw new ArgumentNullException(nameof(m));
            selectedShape = null;
        }

        public void MouseDown(int x, int y)
        {
            // 檢查是否有選到圖形，使用相反順序檢查，以便選到最上層的圖形
            var shapes = _m.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                var shape = shapes[i];
                if (shape.IsPointInShape(x, y))
                {
                    selectedShape = shape;
                    _prevPointX = x;
                    _prevPointY = y;

                    if (shape.IsPointAtText(x, y))
                    {
                        _isDotPressed = true;
                    }
                    else
                    {
                        _isPressed = true;
                    }
                    _m.NotifyModelChanged();
                    return;
                }
            }
            selectedShape = null;
            _m.NotifyModelChanged();
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed || _isDotPressed)
            {
                int displacementX = x - _prevPointX;
                int displacementY = y - _prevPointY;
                if (_isPressed)
                {
                    selectedShape.X += displacementX;
                    selectedShape.Y += displacementY;
                }
                if (_isDotPressed)
                {
                    selectedShape.TextBiasX += displacementX;
                    selectedShape.TextBiasY += displacementY;
                }
                _prevPointX = x;
                _prevPointY = y;
                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(int x, int y)
        {
            _isPressed = false;
            _isDotPressed = false;
        }

        public void OnPaint(IGraphics graphics)
        {
            graphics.ClearAll();
            // 畫出所有的Shape
            foreach (var shape in _m.GetShapes())
            {
                shape.Draw(graphics);
            }
            selectedShape?.DrawBoundingBox(graphics);
        }
    }
}
