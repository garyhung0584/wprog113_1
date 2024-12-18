using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyDrawingForm
{
    public class Decision : Shape
    {
        public Decision(int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
            : base("Decision", id, text, x, y, width, height, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(X, Y, Width, Height);

            int textX = X + Width / 3 + TextBiasX;
            int textY = Y + Height / 3 + TextBiasY;
            graphics.DrawString(ShapeText, textX, textY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();

            Point[] points = new Point[4];
            points[0] = new Point((X + Width / 2), Y);
            points[1] = new Point((X + Width), (Y + Height / 2));
            points[2] = new Point((X + Width / 2), (Y + Height));
            points[3] = new Point(X, (Y + Height / 2));

            path.AddPolygon(points);

            return path.IsVisible(new Point(x, y));
        }

        public override bool IsPointAtText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            int dotX = (X + Width / 3) + TextBiasX + (10 * ShapeText.Length) / 2 - 2;
            int dotY = (Y + Height / 3) + TextBiasY - 5;
            path.AddRectangle(new RectangleF(dotX, dotY, 8, 8));

            return path.IsVisible(new Point(x, y));
        }

        public override int GetConnectorNumber(int x, int y)
        {
            const int connectorSize = 8;
            const int halfConnectorSize = connectorSize / 2;

            // 上方連接器
            Rectangle topConnector = new Rectangle((X + Width / 2) - halfConnectorSize, Y - halfConnectorSize, connectorSize, connectorSize);
            // 左方連接器
            Rectangle leftConnector = new Rectangle(X - halfConnectorSize, (Y + Height / 2) - halfConnectorSize, connectorSize, connectorSize);
            // 下方連接器
            Rectangle bottomConnector = new Rectangle((X + Width / 2) - halfConnectorSize, (Y + Height) - halfConnectorSize, connectorSize, connectorSize);
            // 右方連接器
            Rectangle rightConnector = new Rectangle((X + Width) - halfConnectorSize, (Y + Height / 2) - halfConnectorSize, connectorSize, connectorSize);

            Point point = new Point(x, y);

            if (topConnector.Contains(point))
            {
                return 1; // 上方連接器
            }
            else if (leftConnector.Contains(point))
            {
                return 2; // 左方連接器
            }
            else if (bottomConnector.Contains(point))
            {
                return 3; // 下方連接器
            }
            else if (rightConnector.Contains(point))
            {
                return 4; // 右方連接器
            }
            else
            {
                return -1; // 不在任何連接器上
            }
        }
    }
}
