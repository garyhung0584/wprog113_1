using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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

        public CommandManager commandManager = new CommandManager();

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

        public void AddShape(Shape s)
        {
            shapes.AddShape(s);
            SetSelectMode();
            NotifyModelChanged();
        }
        
        public void RemoveShape(Shape s)
        {
            shapes.RemoveShape(s);
            EnterPointerState();
            NotifyModelChanged();
        }

        public Shape GetShape(string shape, string name, int x, int y, int height, int width)
        {
            return shapes.GetNewShape(shape, name, x, y, height, width);
        }

        public void PointerPressed(int x, int y)
        {
            currentState.MouseDown(x, y);
        }

        public void PointerMoved(int x, int y)
        {
            currentState.MouseMove(x, y);
        }

        public void PointerReleased(int x, int y)
        {
            currentState.MouseUp(x, y);
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
        
        public void Undo()
        {
            commandManager.Undo();
            NotifyModelChanged();
        }

        public void Redo()
        {
            commandManager.Redo();
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
