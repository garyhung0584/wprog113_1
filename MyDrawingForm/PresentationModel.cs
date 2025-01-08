using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void Notify(string propertyName)
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


        public void ManageBackupFiles(string backupFolder)
        {
            var backupFiles = new DirectoryInfo(backupFolder).GetFiles()
                .OrderByDescending(f => f.CreationTime)
                .Skip(5)
                .ToList();

            foreach (var file in backupFiles)
            {
                file.Delete();
            }
        }
        public void AutoSaveAsync(string originalTitle)
        {
            if (_model.hasChange)
            {
                string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
                Directory.CreateDirectory(backupFolder);

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string backupFileName = $"{timestamp}_bak.p0n3";
                string backupFilePath = Path.Combine(backupFolder, backupFileName);

                SaveAsync(backupFilePath);
                ManageBackupFiles(backupFolder);


            }
        }


        public void SaveAsync(string filePath)
        {

            Thread.Sleep(3000);
            // Create a StringBuilder to build the custom format string
            var sb = new StringBuilder();

            // Add shapes to the string
            sb.AppendLine("Shape ID X Y W H Text");
            List<Task> shapeTasks = new List<Task>();
            foreach (var shape in _model.GetShapes())
            {
                shapeTasks.Add(Task.Run(() =>
                {
                    if (shape.ShapeName != "Line")
                    {
                        sb.AppendLine($"{shape.ShapeName} {shape.ShapeId} {shape.X} {shape.Y} {shape.Width} {shape.Height} {shape.ShapeText}");
                    }
                }));
            }

            // Wait for all shape tasks to complete
            Task.WaitAll(shapeTasks.ToArray());

            // Add lines to the string (assuming you have a way to get lines and their connections)
            sb.AppendLine("---------");
            sb.AppendLine("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2");
            List<Task> lineTasks = new List<Task>();
            foreach (Line line in _model.GetLines()) // Assuming LineShape is a subclass of Shape
            {
                lineTasks.Add(Task.Run(() =>
                {
                    var (connShapeId1, connPoint1) = (line.Shape1.ShapeId, line.P1);
                    var (connShapeId2, connPoint2) = (line.Shape2.ShapeId, line.P2);
                    sb.AppendLine($"Line {connShapeId1} {connPoint1} {connShapeId2} {connPoint2}");
                }));
            }

            // Wait for all line tasks to complete
            Task.WaitAll(lineTasks.ToArray());

            sb.AppendLine("---------");
            // Write the formatted string to the file
            File.WriteAllText(filePath, sb.ToString());

            _model.hasChange = false;
            // Log success message
            Console.WriteLine("Save completed successfully.");

        }


        public void Load(string filePath)
        {

            Thread.Sleep(3000);
            // Read the file content
            var lines = File.ReadAllLines(filePath);

            // Clear existing shapes
            _model.shapes = new Shapes();

            // Parse shapes
            int i = 1; // Start after the header line
            while (i < lines.Length && !lines[i].StartsWith("---------"))
            {
                var parts = lines[i].Split(' ');
                if (parts.Length >= 7)
                {
                    string shapeName = parts[0];
                    int id = int.Parse(parts[1]);
                    int x = int.Parse(parts[2]);
                    int y = int.Parse(parts[3]);
                    int w = int.Parse(parts[4]);
                    int h = int.Parse(parts[5]);
                    string text = parts[6];

                    var shape = _model.shapes.GetNewShape(shapeName, text, x, y, w, h);
                    shape.ShapeId = id; // Set the ID explicitly
                    _model.shapes.AddShape(shape);
                }
                i++;
            }

            // Parse lines (connections)
            i += 2; // Skip the "---------" line and the header line for lines
            while (i < lines.Length && !lines[i].StartsWith("---------"))
            {
                var parts = lines[i].Split(' ');
                if (parts.Length >= 5)
                {
                    int connShapeId1 = int.Parse(parts[1]);
                    int connPoint1 = int.Parse(parts[2]);
                    int connShapeId2 = int.Parse(parts[3]);
                    int connPoint2 = int.Parse(parts[4]);

                    Shape shape1 = null;
                    Shape shape2 = null;

                    foreach (Shape shape in _model.GetShapes())
                    {
                        if (shape.ShapeId == connShapeId1)
                        {
                            shape1 = shape;
                        }
                        if (shape.ShapeId == connShapeId2)
                        {
                            shape2 = shape;
                        }
                    }
                    Line line = new Line(shape1, shape2, connPoint1, connPoint2);
                    _model.AddLine(line);
                }
                i++;
            }

            // Notify observers
            _model.NotifyModelChanged();

            // Log success message
            Console.WriteLine("Load completed successfully.");

        }
    }
}
