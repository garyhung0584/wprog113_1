using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands
{
    internal class ConnectorCommand : ICommand
    {
        public void Execute()
        {
            // Draw the shape
        }

        public void UnExecute()
        {
            // Erase the shape
        }
    }
}
