using MyDrawingForm.Commands;
using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyDrawingFormTests1
{
    internal class MockService : TextChangeService
    {

        public MockService(Model model) : base(model)
        {
        }

        public override void ShowTextChangeForm(Shape shape)
        {
        }
    }
}
