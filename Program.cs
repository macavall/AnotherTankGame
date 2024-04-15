using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace TankGame
{
    public class Projectile
    {

        public Projectile(float x, float y, Vector2 lastDirection)
        {
            // Set the projectile position and direction
            this.X = x;
            this.Y = y;
            this.LastDirection = lastDirection;

            // Which direction is the projectile firing?
            // How to draw below is a bit hacky, but it works for now
            if (lastDirection.X == -1 || lastDirection.X == 1)
            {
                this.Width = 20;
                this.Height = 10;
            }
            else            
            {
                this.Width = 10;
                this.Height = 20;
            }
        }

        // Define the projectile direction
        // Will be overwritten when the projectile is created
        public Vector2 LastDirection = new Vector2(0, 1);

        // Define the projectile properties
        public float Width  {get; set;}
        public float Height {get; set;}

        // Define the projectile position
        public float X { get; set; }
        public float Y { get; set; }

        // Define the projectile speed
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

            // Shooting projectiles and event handling for space key
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                projectiles.Add(new Projectile(player.X + player.Width / 2, player.Y + player.Height / 2, lastDirection));
            }

            // Update projectiles positions
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].X += projectiles[i].LastDirection.X * projectiles[i].projectileSpeed * Raylib.GetFrameTime();
                projectiles[i].Y += projectiles[i].LastDirection.Y * projectiles[i].projectileSpeed * Raylib.GetFrameTime();

                // Remove projectiles when they go off screen
                if (projectiles[i].X > screenWidth || projectiles[i].X < 0 ||
                    projectiles[i].Y > screenHeight || projectiles[i].Y < 0)
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        // Draw the game
        static void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Draw player
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
