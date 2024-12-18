using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class ShapeFactory
    {
        public Shape Create(string shape, int id, string text, int x, int y, int width, int height)
        {
            if (shape == "Start")
            {
                return new Start(id, text, x, y, width, height);
            }
            else if (shape == "Terminator")
            {
                return new Terminator(id, text, x, y, width, height);
            }
            else if (shape == "Process")
            {
                return new Process(id, text, x, y, width, height);
            }
            else if (shape == "Decision")
            {
                return new Decision(id, text, x, y, width, height);
            }
            else
            {
                return null;
            }
        }
    }
}
