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

        public float mouseDownPosX;
        public float mouseDownPosY;
        public float mouseUpPosX;
        public float mouseUpPosY;
        public float mouseMovePosX;
        public float mouseMovePosY;
        public int keyDownValue;
        public int keyUpValue;



        public bool isOnPaintCalled = false;



        public void Initialize(Model m)
        {
            this._m = m;
        }

        public void MouseDown(float x, float y)
        {
            mouseDownPosX = x;
            mouseDownPosY = y;
        }

        public void MouseMove(float x, float y)
        {
            mouseMovePosX = x;
            mouseMovePosY = y;
        }
        public void MouseUp(float x, float y)
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
