using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDrawingForm;


namespace MyDrawingFormTests1
{
    internal class MockState : IState
    {
        Model _m;

        public int mouseDownPosX;
        public int mouseDownPosY;
        public int mouseUpPosX;
        public int mouseUpPosY;
        public int mouseMovePosX;
        public int mouseMovePosY;
        public int keyDownValue;
        public int keyUpValue;



        public bool isOnPaintCalled = false;



        public void Initialize(Model m)
        {
            this._m = m;
        }

        public void MouseDown(int x, int y)
        {
            mouseDownPosX = x;
            mouseDownPosY = y;
        }

        public void MouseMove(int x, int y)
        {
            mouseMovePosX = x;
            mouseMovePosY = y;
        }
        public void MouseUp(int x, int y)
        {
            mouseUpPosX = x;
            mouseUpPosY = y;
        }

        public void OnPaint(IGraphics graphics)
        {
            isOnPaintCalled = true;

        }


        public void KeyDown(int keyValue)
        {
            keyDownValue = keyValue;
        }

        public void KeyUp(int keyValue)
        {
            keyUpValue = keyValue;
        }
    }
}
