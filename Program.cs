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
        static float playerSpeed = 150.0f;
        static Vector2 lastDirection = new Vector2(0, -1);

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

        // Draw the game
        static void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Draw player
            if (player.X < 0)
            {
                player.X = 0;
            }
            else if (player.X  + player.Width > screenWidth)
            {
                player.X = screenWidth - player.Width;
            }
            else if (player.Y < 0)
            {
                player.Y = 0;
            }
            else if (player.Y + player.Height > screenHeight)
            {
                player.Y = screenHeight - player.Height;
            }


            Raylib.DrawRectangleRec(player, Color.Blue);

            // Draw projectiles
            foreach (var projectile in projectiles)
            {
                Raylib.DrawRectangleRec(new Rectangle() { X = projectile.X, Y = projectile.Y, Width = projectile.Width, Height = projectile.Height}, Color.Red);
            }

            Raylib.EndDrawing();
        }
    }
}
