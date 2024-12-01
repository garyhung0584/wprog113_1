using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class PointerState : IState
    {
        Model _m;

        // 紀錄選取的圖
        public List<Shape> selectedShapes = new List<Shape>();
        // Ctrl鍵的KeyValue
        const int CTRL_KEY = 17;
        // 紀錄是否按下Ctrl鍵
        bool _isCtrlKeyDown;

        private float _prevPointX;
        private float _prevPointY;
        private bool _isPressed = false;

        public void Initialize(Model m)
        {
            this._m = m;
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShapes
            selectedShapes.Clear();
            _isCtrlKeyDown = false;
        }

        public void MouseDown(float x, float y)
        {
            // 檢查是否有選到圖形，使用相反順序檢查，以便選到最上層的圖形
            foreach (Shape _shape in Enumerable.Reverse(_m.GetShapes()))
            {

                if (_shape.IsPointInShape(x, y))
                {
                    if (_isCtrlKeyDown)
                    {
                        //若按下 Ctrl 鍵，則新增選取，Bug: 可能重複選取同一個圖形
                        if (!selectedShapes.Contains(_shape))
                        {
                            selectedShapes.Add(_shape);
                        }
                        else
                        {
                            selectedShapes.Remove(_shape);
                        }

                    }
                    else
                    {
                        if (selectedShapes.Contains(_shape))
                        {
                            _prevPointX = x;
                            _prevPointY = y;
                            _isPressed = true;
                        }
                        else
                        {
                            // 若沒按下Ctrl鍵，則清空selectedShapes，再新增選取的圖形
                            selectedShapes.Clear();
                            AddSelectedShape(_shape);
                        }
                    }
                    _m.NotifyModelChanged();
                    return;
                }
            }
            // 若沒有選到任何圖形，則清空selectedShapes，但是如果按下Ctrl鍵，則selectedShapes不變
            if (!_isCtrlKeyDown)
                selectedShapes.Clear();
            _m.NotifyModelChanged();
        }

        public void AddSelectedShape(Shape _shape)
        {
            if (!selectedShapes.Contains(_shape))
            {
                selectedShapes.Add(_shape);
            }
        }

        public void MouseMove(float x, float y)
        {
            if (_isPressed)
            {
                int _displacementX = (int)x - (int)_prevPointX;
                int _displacementY = (int)y - (int)_prevPointY;

                foreach (Shape _shape in selectedShapes)
                {
                    _shape.X += _displacementX;
                    _shape.Y += _displacementY;
                }
                _prevPointX = x;
                _prevPointY = y;
                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(float x, float y)
        {
            _isPressed = false;
        }

        public void OnPaint(IGraphics graphics)
        {
            graphics.ClearAll();
            // 畫出所有的Shape
            foreach (Shape _shape in _m.GetShapes())
            {
                _shape.Draw(graphics);
            }
            foreach (Shape selShape in selectedShapes)
            {
                selShape.DrawBoundingBox(graphics);
            }
        }

        public void KeyDown(int keyValue)
        {
            if (keyValue == CTRL_KEY)
                _isCtrlKeyDown = true;
        }

        public void KeyUp(int keyValue)
        {
            if (keyValue == CTRL_KEY)
                _isCtrlKeyDown = false;
        }
    }
}
