using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands
{
    internal class DataGridCommand : ICommand
    {
        Model _m;
        List<Line> _lines = new List<Line>();

        Shape _shape;
        public DataGridCommand(Model m, Shape shape)
        {
            _m = m;
            _shape = shape;
            foreach (Line line in m.GetLines())
            {
                if (_shape == line.Shape1 || _shape == line.Shape2)
                {
                    _lines.Add(line);
                }
            }
        }
        public void Execute()
        {
            _m.RemoveShape(_shape);
            foreach (Line line in _lines)
            {
                _m.RemoveLine(line);
            }
        }

        public void UnExecute()
        {
            _m.AddShape(_shape);
            foreach (Line line in _lines)
            {
                _m.AddLine(line);
            }
        }
    }
}
