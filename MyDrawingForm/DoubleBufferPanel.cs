﻿using System.Windows.Forms;

namespace MyDrawingForm
{
    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            // Note:
            //    The DoubleBuffered property is a protected member of Panel.
            //    Thus, to initialize DoubleBuffered, we need to inherit Panel.
            //
            DoubleBuffered = true;
        }
    }
}
