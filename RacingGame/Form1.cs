﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {
        private int backgroundPositionY;
        private int backgroundSpeed = 5;
        private PlayerCar playerCar;
        private Scene scene;
        Random random;

        private bool isGameOver = false;

        // Milliseconds between AI car spawns
        private int aiCarSpawnIntervalMin = 1000; // Minimum spawn interval
        private int aiCarSpawnIntervalMax = 2500; // Maximum spawn interval
        private int timeSinceLastSpawn = 0;
        private int aiCarSpawnInterval;

        
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            ClientSize = new Size(300, 600);

            BackColor = Color.DimGray;
            DoubleBuffered = true;
            random = new Random();
        }

        private void InitializeGame()
        {
            // Set the initial position of the background
            backgroundPositionY = 0;

            // Create the player car
            playerCar = new PlayerCar(125, 500, 50, 100, 10, Color.GreenYellow);

            // Create the scene
            scene = new Scene(ClientSize.Width, ClientSize.Height);
            scene.AddPlayerCar(playerCar);

            // Set up the game loop timer
            var gameTimer = new Timer();
            gameTimer.Interval = 16; // 60 FPS
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }


        private void GameLoop(object sender, EventArgs e)
        {
            // Stop updating the game if it's over
            if (isGameOver)
            {
                return;
            }

            // Check collision between player car and AI cars
            PerformCollisionDetection();

            // Update the position of the background
            backgroundPositionY += backgroundSpeed;

            // Check if the background has scrolled off the screen
            if (backgroundPositionY >= ClientSize.Height)
            {
                // Reset the background position
                backgroundPositionY = 0;
            }

            // Update the AI cars
            foreach (var aiCar in scene.aiCars)
            {
                aiCar.Update();
            }


            // Spawn new AI cars at random intervals
            timeSinceLastSpawn += 16;
            if (timeSinceLastSpawn >= aiCarSpawnInterval)
            {
                SpawnAICar();
                timeSinceLastSpawn = 0;

                // Generate a new random spawn interval for the next AI car
                aiCarSpawnInterval = random.Next(aiCarSpawnIntervalMin, aiCarSpawnIntervalMax);
            }

            // Perform collision detection
            PerformCollisionDetection();

            // Redraw the game window
            Invalidate();
        }

        private void PerformCollisionDetection()
        {
            Rectangle playerCarBounds = playerCar.GetBounds();

            foreach (var aiCar in scene.aiCars)
            {
                Rectangle aiCarBounds = aiCar.GetBounds();

                if (playerCarBounds.IntersectsWith(aiCarBounds))
                {
                    // Collision detected
                    isGameOver = true;
                    DialogResult dr = MessageBox.Show("You collided with another car.\nDo you want to play again?", "Game Over!" ,MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ResetGame();
                    }
                    else
                    {
                        Close();
                    }
                    break;
                }
            }
        }

        void ResetGame()
        {
            // Reset game state and variables
            isGameOver = false;

            // Reset background position
            backgroundPositionY = 0;

            // Reset player car
            playerCar.Reset();

            // Clear AI cars from the scene
            scene.aiCars.Clear();

            // Reset AI car spawn interval
            timeSinceLastSpawn = 0;
            aiCarSpawnInterval = random.Next(aiCarSpawnIntervalMin, aiCarSpawnIntervalMax);

            // Redraw the game window
            Invalidate();
        }

        private void SpawnAICar()
        {
            int laneCount = 3;
            int laneWidth = ClientSize.Width / laneCount;

            // Generate a random lane index
            int laneIndex = random.Next(0, laneCount);

            // Calculate the X position based on the selected lane
            int laneX = laneIndex * laneWidth + laneWidth / 2;

            // Create a new AI car at the top of the screen
            int carWidth = 50;
            int carHeight = 100;
            int carSpeed = 3;
            Color carColor = Color.Blue;
            AICar aiCar = new AICar(laneX - carWidth / 2, -carHeight, carWidth, carHeight, carSpeed, carColor);

            // Add the AI car to the scene
            scene.aiCars.Add(aiCar);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the background
            Brush brush = new SolidBrush(Color.DimGray);
            e.Graphics.FillRectangle(brush, 0, 0, Width, Height);

            // Calculate the interpolated position of the lanes
            float interpolatedPositionY = (float)(ClientSize.Height - (backgroundPositionY % (ClientSize.Height * 2))) / ClientSize.Height;

            // Draw the lane markings
            Pen lanePen = new Pen(Color.White, 5);
            lanePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            lanePen.DashPattern = new float[] { 20f, 20f };
            int laneCount = 3;
            int laneWidth = ClientSize.Width / laneCount;

            float laneY1 = -interpolatedPositionY * ClientSize.Height;
            for (int i = 1; i < laneCount; i++)
            {
                int laneX = i * laneWidth;
                e.Graphics.DrawLine(lanePen, laneX, laneY1, laneX, ClientSize.Height + laneY1);
            }

            float laneY2 = laneY1 + ClientSize.Height;
            for (int i = 1; i < laneCount; i++)
            {
                int laneX = i * laneWidth;
                e.Graphics.DrawLine(lanePen, laneX, laneY2, laneX, ClientSize.Height + laneY2);
            }

            // Draw the player car
            playerCar.Draw(e.Graphics);

            // Draw the AI cars
            foreach (var aiCar in scene.aiCars)
            {
                aiCar.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ignore input if the game is over
            if (isGameOver)
            {
                return; 
            }

            if (e.KeyCode == Keys.Left)
            {
                playerCar.MoveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerCar.MoveRight();
            }
        }
    }
}
