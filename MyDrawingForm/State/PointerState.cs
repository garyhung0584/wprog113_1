using MyDrawingForm.Commands;
using System;
using System.Windows.Forms;

namespace MyDrawingForm
{
    internal class PointerState : IState
    {
        private Model _m;
        public TextChangeService _textChangeService;

        // 紀錄選取的圖
        public Shape selectedShape;

        private int _prevPointX;
        private int _prevPointY;
        private int _originalX;
        private int _originalY;
        private bool _isPressed = false;
        private bool _isDotPressed = false;
        private bool _isPressedOnce = false;


        public void Initialize(Model m)
        {
            _m = m;
            _textChangeService = new TextChangeService(m);
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
                    _originalX = shape.X;
                    _originalY = shape.Y;
                    _prevPointX = x;
                    _prevPointY = y;

                    if (shape.IsPointAtText(x, y))
                    {
                        Console.Write(x);
                        Console.WriteLine(y);
                        if (_isPressedOnce)
                        {
                            _textChangeService.ShowTextChangeForm(shape);
                            _isPressedOnce = false;
                            return;
                        }
                        else
                        {
                            _isPressedOnce = true;
                        }
                        _isDotPressed = true;
                        _originalX = shape.TextBiasX;
                        _originalY = shape.TextBiasY;
                    }
                    else
                    {
                        _isPressed = true;
                        _originalX = shape.X;
                        _originalY = shape.Y;
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
            if (_isPressed)
            {
                _m.commandManager.Execute(new MoveCommand(selectedShape, _originalX, _originalY));
            }
            if (_isDotPressed)
            {
                _m.commandManager.Execute(new TextMoveCommand(selectedShape, _originalX, _originalY));
            }
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
            foreach (Line line in _m.GetLines())
            {
                line.Draw(graphics);
            }
        }
    }
}
