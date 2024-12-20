using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyDrawingForm.Tests
{
    public class MockCommand : ICommand
    {
        public bool Executed { get; private set; } = false;
        public bool UnExecuted { get; private set; } = false;

        public void Execute()
        {
            Executed = true;
            UnExecuted = false;
        }

        public void UnExecute()
        {
            UnExecuted = true;
            Executed = false;
        }
    }
}
