﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    internal class Shapes
    {
        public List<Shape> shapeList = new List<Shape>();
        private static readonly ShapeFactory shapeFactory = new ShapeFactory();

        public List<Shape> GetShapes()
        {
            return shapeList;
        }
        public Shape GetNewShape(string shape, string name, float x, float y, float height, float width)
        {
            int id;
            if (shapeList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = shapeList.Last().ShapeId + 1;
            }
            return shapeFactory.Create(shape, id, name, x, y, height, width);
        }

        public void CreateShape(string shape, string name, float x, float y, float height, float width)
        {
            shapeList.Add(GetNewShape(shape, name, x, y, height, width));
        }
    }
}
