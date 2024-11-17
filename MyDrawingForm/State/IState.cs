using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal interface IState
    {
        void Initialize(Model m);
        void OnPaint(IGraphics g);
        void MouseDown(float x, float y);
        void MouseMove(float x, float y);
        void MouseUp(float x, float y);
        void KeyDown(int keyValue);
        void KeyUp(int keyValue);
    }
}
