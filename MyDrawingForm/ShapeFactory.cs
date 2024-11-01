using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class ShapeFactory
    {
        public Shape Create(string shape, int id, string text, float x, float y, float height, float width)
        {
            if (shape == "Start")
            {
                return new Start(id, text, x, y, height, width);
            }
            else if (shape == "Terminator")
            {
                return new Terminator(id, text, x, y, height, width);
            }
            else if (shape == "Process")
            {
                return new Process(id, text, x, y, height, width);
            }
            else if (shape == "Decision")
            {
                return new Decision(id, text, x, y, height, width);
            }
            else
            {
                throw new ArgumentException("Invalid shape type");
            }
        }

    }
}
