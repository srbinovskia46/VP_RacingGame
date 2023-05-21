using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    public class Aicoins
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }
        public Point Location { get; internal set; }

        public Aicoins(int x, int y, int width, int height, int speed, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Color = color;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, X, Y, Width, Height);
            Pen pen = new Pen(Color.Orange, 3);
            g.DrawEllipse(pen, X, Y, Width, Height);
            pen.Dispose();
        }

        public void Update()
        {
            MoveDown();
        }
        public void setlocation(int x,int y)
        {
            Location = new Point(x, y);
        }
        public void MoveDown()
        {
            Y += Speed;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }
}
