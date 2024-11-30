using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyDrawingForm
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();

        IState pointerState;
        IState drawingState;
        public IState currentState;

        internal Shapes shapes = new Shapes();
        private string _mode = "";

        public Model()
        {
            pointerState = new PointerState();
            drawingState = new DrawingState((PointerState)pointerState);
            currentState = pointerState;
        }

        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
        }

        public void EnterDrawingState()
        {
            drawingState.Initialize(this);
            currentState = drawingState;
        }

        public void AddShape(string shape, string name, float x, float y, float height, float width)
        {
            shapes.CreateShape(shape, name, x, y, height, width);
            SetSelectMode();
            NotifyModelChanged();
        }

        public void PointerPressed(float x, float y)
        {
            currentState.MouseDown(x, y);
        }

        public void PointerMoved(float x, float y)
        {
            currentState.MouseMove(x, y);
        }

        public void PointerReleased(float x, float y)
        {
            currentState.MouseUp(x, y);
        }
        public void KeyDown(int keyValue)
        {
            // 注意：同一個鍵持續按著不放會自動Auto repeat
            currentState.KeyDown(keyValue);
        }

        public void KeyUp(int keyValue)
        {
            currentState.KeyUp(keyValue);
        }

        public void Draw(IGraphics graphics)
        {
            currentState.OnPaint(graphics);
        }

        public void SetDrawingMode(string shape)
        {
            _mode = shape;
            EnterDrawingState();
            NotifyModelChanged();
        }

        public void SetSelectMode()
        {
            _mode = "";
            EnterPointerState();
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

        public void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }
    }
}
