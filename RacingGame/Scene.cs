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
            int laneCount = 3;
            int laneWidth = 300 / laneCount;

            // Generate a random lane index
            int laneIndex = random.Next(0, laneCount);

            // Calculate the X position based on the selected lane
            int laneX = laneIndex * laneWidth + laneWidth / 2;

            // Create a new AI car at the top of the screen
            int carWidth = 50;
            int carHeight = 100;
            int carSpeed = 3;

            // Get a random car image from the Resources folder
            string[] carImages = { 
                "Resources/aiCar1.png", 
                "Resources/aiCar2.png", 
                "Resources/aiCar3.png", 
                "Resources/aiCar4.png", 
                "Resources/aiCar5.png" };

            int randomIndex = random.Next(0, carImages.Length);  
            Image carImage = Image.FromFile(carImages[randomIndex]);

            // Create the AI car using the car image
            AICar aiCar = new AICar(laneX - carWidth / 2, -carHeight, carWidth, carHeight, carSpeed, carImage);

            // Add the AI car to the scene
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
