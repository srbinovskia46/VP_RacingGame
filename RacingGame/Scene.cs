using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    class Scene
    {
        public List<AICar> aiCars;
        private PlayerCar playerCar;
        private Random random;
        private int windowWidth;
        private int windowHeight;

        public Scene(int windowWidth, int windowHeight)
        {
            aiCars = new List<AICar>();
            random = new Random();
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }

        public void AddAICar(AICar aiCar)
        {
            aiCars.Add(aiCar);
        }

        public void RemoveAICar(AICar aiCar)
        {
            aiCars.Remove(aiCar);
        }

        public void SetPlayerCar(PlayerCar playerCar)
        {
            this.playerCar = playerCar;
        }

        public void SpawnAICar()
        {
            int x = random.Next(0, 3) * (windowWidth / 3); // Spawn in one of three lanes
            int y = -random.Next(100, 300); // Spawn above the visible area
            int width = 50;
            int height = 100;
            int speed = 5;
            Color color = Color.GreenYellow;

            AICar aiCar = new AICar(x, y, width, height, speed, color);
            aiCars.Add(aiCar);
        }

        internal void AddPlayerCar(PlayerCar playerCar)
        {
            this.playerCar = playerCar;
        }

        public void Update()
        {
            // Here's a simple example where an AI car is spawned randomly every few frames
            if (random.Next(0, 300) < 3) // Adjust the probability as needed
            {
                SpawnAICar();
            }

            // Update all AI cars
            foreach (var aiCar in aiCars)
            {
                aiCar.Update();

                if (aiCar.Y > windowHeight)
                {
                    // Respawn the AI car at the top
                    aiCar.Y = -random.Next(100, 300);
                }
            }

        }

        internal void Draw(Graphics g)
        {
            playerCar.Draw(g);

            foreach (var aiCar in aiCars)
            {
                aiCar.Draw(g);
            }

        }
    }
}
