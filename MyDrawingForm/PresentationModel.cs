using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isStartChecked;
        private bool _isTerminatorChecked;
        private bool _isProcessChecked;
        private bool _isDecisionChecked;
        private bool _isSelectChecked;
        private bool _isCreateEnabled = false;
        private bool _isConnectorChecked = false;
        private bool _isUndoEnabled = false;
        private bool _isRedoEnabled = false;

        private string _shape;
        private string _text;
        private string _x;
        private string _y;
        private string _width;
        private string _height;

        private Cursor _cursor;

        Model _model;

        public Model model
        {
            get
            {
                return _model;
            }
        }

        public PresentationModel(Model model)
        {
            this._model = model;

            _model.ModelChanged += UpdateState;
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsCreateEnabled
        {
            get
            {
                return _isCreateEnabled;
            }
        }
        public bool IsStartChecked
        {
            get
            {
                return _isStartChecked;
            }
        }
        public bool IsTerminatorChecked
        {
            get
            {
                return _isTerminatorChecked;
            }
        }
        public bool IsProcessChecked
        {
            get
            {
                return _isProcessChecked;
            }
        }
        public bool IsDecisionChecked
        {
            get
            {
                return _isDecisionChecked;
            }
        }
        public bool IsSelectChecked
        {
            get
            {
                return _isSelectChecked;
            }
        }
        public bool IsConnectorChecked
        {
            get
            {
                return _isConnectorChecked;
            }
        }
        public bool IsUndoEnabled
        {
            get
            {
                return _isUndoEnabled;
            }
        }
        public bool IsRedoEnabled
        {
            get
            {
                return _isRedoEnabled;
            }
        }

        public Color NameLabelColor
        {
            get
            {
                if (!IsNameValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public Color XLabelColor
        {
            get
            {
                if (!IsXValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public Color YLabelColor
        {
            get
            {
                if (!IsYValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public Color WidthLabelColor
        {
            get
            {
                if (!IsWidthValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public Color HeightLabelColor
        {
            get
            {
                if (!IsHeightValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public Cursor CurrentCursor
        {
            get
            {
                return _cursor;
            }
        }

        public void SetStartMode()
        {
            _model.SetDrawingMode("Start");
        }
        public void SetTerminatorMode()
        {
            _model.SetDrawingMode("Terminator");
        }
        public void SetProcessMode()
        {
            _model.SetDrawingMode("Process");
        }
        public void SetDecisionMode()
        {
            _model.SetDrawingMode("Decision");
        }
        public void SetSelectMode()
        {
            _model.SetSelectMode();
        }

        public void SetConnectorMode()
        {
            _model.SetConnectorMode();
        }

        public void Undo()
        {
            _model.Undo();
        }

        public void Redo()
        {
            _model.Redo();
        }

        public void UpdateState()
        {
            string mode = _model.GetDrawingMode();

            if (mode != "")
            {
                _cursor = Cursors.Cross;
            }
            else
            {
                _cursor = Cursors.Default;
            }

            _isStartChecked = mode == "Start";
            _isTerminatorChecked = mode == "Terminator";
            _isProcessChecked = mode == "Process";
            _isDecisionChecked = mode == "Decision";
            _isConnectorChecked = mode == "Connector";
            _isSelectChecked = mode == "";

            _isUndoEnabled = _model.commandManager.IsUndoEnabled;
            _isRedoEnabled = _model.commandManager.IsRedoEnabled;
        }

        public void NameTextBoxTextChanged(string name)
        {
            _text = name;
            CreateBlockChanged();
        }
        public void XTextBoxTextChanged(string x)
        {
            _x = x;
            CreateBlockChanged();
        }
        public void YTextBoxTextChanged(string y)
        {
            _y = y;
            CreateBlockChanged();
        }
        public void WidthTextBoxTextChanged(string width)
        {
            _width = width;
            CreateBlockChanged();
        }
        public void HeightTextBoxTextChanged(string height)
        {
            _height = height;
            CreateBlockChanged();
        }
        public void ShapeAddComboBoxSelectedIndexChanged(string shape)
        {
            _shape = shape;
            CreateBlockChanged();
        }
        public bool IsShapeValid()
        {
            return _shape == "Start" || _shape == "Terminator" || _shape == "Process" || _shape == "Decision";
        }
        public bool IsNameValid()
        {
            return _text != "";
        }
        public bool IsXValid()
        {
            try
            {
                int x = Convert.ToInt32(_x);
                return x > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsYValid()
        {
            try
            {
                int y = Convert.ToInt32(_y);
                return y > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsWidthValid()
        {
            try
            {
                int width = Convert.ToInt32(_width);
                return width > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsHeightValid()
        {
            try
            {
                int height = Convert.ToInt32(_height);
                return height > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CreateBlockChanged()
        {
            if (IsNameValid() && IsShapeValid() && IsXValid() && IsYValid() && IsWidthValid() && IsHeightValid())
            {
                _isCreateEnabled = true;
            }
            else
            {
                _isCreateEnabled = false;
            }
            Notify("IsCreateEnabled");
        }

        public void AddShape()
        {
            Shape s = _model.GetShape(_shape, _text, Convert.ToInt32(_x), Convert.ToInt32(_y), Convert.ToInt32(_height), Convert.ToInt32(_width));
            _model.AddShape(s);
        }
    }
}
