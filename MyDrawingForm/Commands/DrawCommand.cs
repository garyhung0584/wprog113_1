using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class DrawCommand : ICommand
    {
        Shape shape;
        Model model;
        public DrawCommand(Model m, Shape s)
        {
            model = m;
            shape = s;
        }

        public void Execute()
        {
            model.AddShape(shape);
        }
        
        public void UnExecute()
        {
            model.RemoveShape(shape);
        }
    }
}
