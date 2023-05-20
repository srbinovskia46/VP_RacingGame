using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public class PlayerCar
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }

        public PlayerCar(int x, int y, int width, int height, int speed, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Color = color;
        }

        public void MoveLeft()
        {
            X -= Speed;
        }

        public void MoveRight()
        {
            X += Speed;
        }

        public void Draw(Graphics g)
        {
            /*using (Brush brush = new SolidBrush(Color))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }*/
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Width, Height);
        }

        public void Update()
        {
            // Update logic for the player car
            // For example, you might check for user input or perform collision detection

            // Here's a simple example where the player car moves based on keyboard input
            
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        internal void Reset()
        {
            X = 225;
            Y = 500;
        }
    }
}
