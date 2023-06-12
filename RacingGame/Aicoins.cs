using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
        public Font font { get; set; }
        public Point Location { get; internal set; }

        public Aicoins(int x, int y, int width, int height, int speed, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Color = color;
            font=new Font("Arial",13);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            Brush fb = new SolidBrush(Color.Orange);
            g.FillEllipse(brush, X, Y, Width, Height);
            Pen pen = new Pen(Color.Orange, 3);
            g.DrawEllipse(pen, X, Y, Width, Height);
            g.DrawString(string.Format("C"), font, fb, X+3, Y+3);
            pen.Dispose();
            fb.Dispose();
            brush.Dispose();
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
