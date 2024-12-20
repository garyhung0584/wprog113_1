using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands
{
    internal class TextChangeCommand : ICommand
    {
        Shape _shape;
        string _originalText;
        string _newText;
        public TextChangeCommand(Shape s, string newText)
        {
            _shape = s;
            _originalText = s.ShapeText;
            _newText = newText;
        }

        public void Execute()
        {
            _shape.ShapeText = _newText;
        }
        public void UnExecute()
        {
            _shape.ShapeText = _originalText;
        }

    }
}
