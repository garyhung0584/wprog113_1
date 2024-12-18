using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands
{
    internal class TextMoveCommand : ICommand
    {
        Shape _shape;
        int _newX, _newY, _originalX, _originalY;
        public TextMoveCommand(Shape s, int originalX, int originalY)
        {
            _shape = s;
            _newX = s.TextBiasX;
            _newY = s.TextBiasY;
            _originalX = originalX;
            _originalY = originalY;
        }
        public void Execute()
        {
            _shape.TextBiasX = _newX;
            _shape.TextBiasY = _newY;
        }

        public void UnExecute()
        {
            _shape.TextBiasX = _originalX;
            _shape.TextBiasY = _originalY;
        }
    }
}
