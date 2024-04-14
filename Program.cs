using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace TankGame
{
    public class Projectile()
    {
        public int X { get; set; }
        public int Y { get; set; }
        public float projectileSpeed = 200.0f;
    }

    class Program
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

        static void Main(string[] args)
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

        static void UpdateGame()
        {
            // Movement logic for the player
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                player.X += playerSpeed * Raylib.GetFrameTime();
                lastDirection = new Vector2(1, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                player.X -= playerSpeed * Raylib.GetFrameTime();
                lastDirection = new Vector2(-1, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                player.Y -= playerSpeed * Raylib.GetFrameTime();
                lastDirection = new Vector2(0, -1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                player.Y += playerSpeed * Raylib.GetFrameTime();
                lastDirection = new Vector2(0, 1);
            }

            // Shooting projectiles
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                projectiles.Add(new Rectangle(player.X + player.Width / 2, player.Y + player.Height / 2, 10, 20));
            }

            // Update projectiles positions
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].X += lastDirection.X * projectileSpeed * Raylib.GetFrameTime();
                projectiles[i].Y += lastDirection.Y * projectileSpeed * Raylib.GetFrameTime();

                // Remove projectiles when they go off screen
                if (projectiles[i].X > screenWidth || projectiles[i].x < 0 ||
                    projectiles[i].y > screenHeight || projectiles[i].y < 0)
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        static void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            // Draw player
            Raylib.DrawRectangleRec(player, Color.BLUE);

            // Draw projectiles
            foreach (var projectile in projectiles)
            {
                Raylib.DrawRectangleRec(projectile, Color.RED);
            }

            Raylib.EndDrawing();
        }
    }
}
