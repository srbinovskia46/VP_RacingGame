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
        public Image carImage { get; set; }

        public PlayerCar(int x, int y, int width, int height, int speed, Image playerCar)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            carImage = playerCar;
        }

        public void MoveLeft()
        {
            X -= Speed;

            // Check if X is out of border
            if (X <= 0)
            {
                X = 0;
            }
 
        }

        public void MoveRight()
        {
            
            X += Speed;

            // Check if X is out of border
            if (X > 250)
            {
                X = 250;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.carImage, X, Y, Width, Height);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        public void Reset()
        {
            X = 125;
            Y = 500;
        }
    }
}
