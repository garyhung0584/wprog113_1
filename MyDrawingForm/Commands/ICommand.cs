using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal interface ICommand
    {
        void Execute();

        void UnExecute();
    }
}
