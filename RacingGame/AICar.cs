using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    class AICar
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }
        public Image carImage { get; set; }

        public AICar(int x, int y, int width, int height, int speed, Image aiCar)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            carImage = aiCar;
        }

        public void Draw(Graphics g)
        {
            //Brush brush = new SolidBrush(Color);
            //g.FillRectangle(brush, X, Y, Width, Height);
            g.DrawImage(carImage, X, Y, Width, Height);
        }

        public void Update()
        {
            MoveDown();
        }

        public void MoveDown()
        {
            Y += Speed;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height-5);
        }
    }
}

