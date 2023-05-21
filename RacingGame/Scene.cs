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
        public List<Aicoins> acoins;
        private PlayerCar playerCar;
        private Random random;
        private int windowWidth;
        private int windowHeight;

        public Scene(int windowWidth, int windowHeight)
        {
            aiCars = new List<AICar>();
            acoins= new List<Aicoins>();
            random = new Random();
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }

        public void AddAICar(AICar aiCar)
        {
            aiCars.Add(aiCar);
        }
        public void AddAICoin(Aicoins aicoin)
        {
            acoins.Add(aicoin);
        }
        public void RemoveAICar(AICar aiCar)
        {
            aiCars.Remove(aiCar);
        }
        public void RemoveAICoin(Aicoins aiCoin)
        {
            acoins.Remove(aiCoin);
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
        public void SpawnAICoin()
        {
            int x = random.Next(0, 3) * (windowWidth / 3); // Spawn in one of three lanes
            int y = -random.Next(100, 300); // Spawn above the visible area
            int width = 50;
            int height = 100;
            int speed = 5;
            Color color = Color.Yellow;

            Aicoins aiCoin = new Aicoins(x, y, width, height, speed, color);
            acoins.Add(aiCoin);
        }
        internal void AddPlayerCar(PlayerCar playerCar)
        {
            this.playerCar = playerCar;
        }

        public void Update()
        {

            if (random.Next(0, 300) < 3)
            {
                SpawnAICar();
                SpawnAICoin();
            }

            // Update all AI cars and coins
            foreach (var aiCar in aiCars)
            {
                aiCar.Update();

                if (aiCar.Y > windowHeight)
                {
                    // Respawn the AI car at the top
                    aiCar.Y = -random.Next(100, 300);
                }
            }
            foreach (var aicoin in acoins)
            {
                aicoin.Update();

                if (aicoin.Y > windowHeight)
                {
                    // Respawn the AI coin at the top
                    aicoin.Y = -random.Next(100, 300);
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
            foreach (var aiCoin in acoins)
            {
                aiCoin.Draw(g);
            }

        }
    }
}
