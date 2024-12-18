using MyDrawingForm.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    internal class ConnectorState : IState
    {
        Model _m;

        Shape shape1, shape2, onShape;

        LineHint _hint;

        int _connector, _connector1, _connector2;

        public void Initialize(Model m)
        {
            this._m = m;
            if(_m.GetShapes().Count() <= 1)
            {
                _m.SetSelectMode();
                _m.NotifyModelChanged();
            }

        }
        public void OnPaint(IGraphics graphics)
        {
            foreach (Shape shape in _m.GetShapes())
            {
                shape.Draw(graphics);
            }

            foreach (Line line in _m.GetLines())
            {
                line.Draw(graphics);
            }
            _hint?.DrawHint(graphics);
            onShape?.DrawConnector(graphics);
        }
        public void MouseDown(int x, int y)
        {
            var shapes = _m.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                var shape = shapes[i];
                _connector = shape.GetConnectorNumber(x, y);
                if (_connector != -1)
                {
                    if (_hint == null)
                    {
                        _hint = new LineHint(x, y, x, y);
                    }
                    else
                    {
                        _hint.X2 = x;
                        _hint.Y2 = y;
                    }

                    if (shape1 == null)
                    {
                        shape1 = shape;
                        _connector1 = _connector;
                    }
                    else if (shape2 == null)
                    {
                        if (shape1 != shape)
                        {
                            shape2 = shape;
                            _connector2 = _connector;
                            var line = new Line(shape1, shape2, _connector1, _connector2);
                            _m.commandManager.Execute(new ConnectorCommand(_m, line));

                            _hint = null;
                            shape1 = null;
                            shape2 = null;

                            _m.SetSelectMode();
                            _m.NotifyModelChanged();
                            return;
                        }
                    }
                }
            }
            _m.NotifyModelChanged();
        }

        public void MouseMove(int x, int y)
        {
            var shapes = _m.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                var shape = shapes[i];
                if (shape.IsPointInShape(x, y))
                {
                    onShape = shape;
                    _m.NotifyModelChanged();
                }
            }
            if (_hint != null)
            {
                _hint.X2 = x;
                _hint.Y2 = y;
                _m.NotifyModelChanged();
            }
        }
        public void MouseUp(int x, int y)
        {

        }
    }
}
