using MyDrawingForm.Commands;
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
        IState connectorState;

        public IState currentState;

        internal Shapes shapes = new Shapes();
        private string _mode = "";

        List<Line> lines = new List<Line>();

        public bool hasChange = false;


        public Model()
        {
            pointerState = new PointerState();
            drawingState = new DrawingState((PointerState)pointerState);
            connectorState = new ConnectorState();
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

        public void EnterConnectorState()
        {
            connectorState.Initialize(this);
            currentState = connectorState;
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
        public void DataGridRemoveShape(Shape s)
        {
            commandManager.Execute(new DataGridCommand(this, s));
            NotifyModelChanged();
        }

        public Shape GetShape(string shape, string name, int x, int y, int height, int width)
        {
            return shapes.GetNewShape(shape, name, x, y, height, width);
        }

        public List<Line> GetLines()
        {
            return lines;
        }

        public void AddLine(Line l)
        {
            lines.Add(l);
            NotifyModelChanged();
        }
        public void RemoveLine(Line l)
        {
            lines.Remove(l);
            NotifyModelChanged();
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

        public void SetConnectorMode()
        {
            _mode = "Connector";
            EnterConnectorState();
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
            hasChange = true;
            if (ModelChanged != null)
                ModelChanged();
        }
    }
}
