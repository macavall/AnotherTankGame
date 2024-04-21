using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace TankGame
{
    public partial class Program
    {
        // Define the window dimensions
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Define the player (square) properties
        static Rectangle player = new Rectangle(400, 225, 30, 30);
        static float playerSpeed = 100.0f;
        static Vector2 lastDirection = new Vector2(0, -1);
        
        static double lastShotTime = 0;
        static double fireRate = 500; // milliseconds

        // List to keep track of projectiles
        static List<Projectile> projectiles = new List<Projectile>();
        //static float projectileSpeed = 200.0f;

        public static void Main(string[] args)
        {
            // Initialize the window
            Raylib.InitWindow(screenWidth, screenHeight, "Raylib Example - Square and Projectiles");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                // Update
                UpdateGame();

                // Draw
                DrawGame();
            }

            // Close window and unload resources
            Raylib.CloseWindow();
        }

        public static void UpdateGame()
        {
            HandlePlayerInput();

            HandleProjectileInput();

            UpdateProjectiles();
        }
    }
}
