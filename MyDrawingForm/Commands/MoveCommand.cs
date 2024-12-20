using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands
{
    internal class MoveCommand : ICommand
    {
        Shape shape;
        int _newX, _newY, _originalX, _originalY;
        public MoveCommand(Shape s, int originalX, int originalY)
        {
            shape = s;
            _newX = shape.X;
            _newY = shape.Y;
            _originalX = originalX;
            _originalY = originalY;
        }
        public void Execute()
        {
            shape.X = _newX;
            shape.Y = _newY;
        }

        public void UnExecute()
        {
            shape.X = _originalX;
            shape.Y = _originalY;
        }
    }
}
