using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace TankGame
{
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
                switch(GetDirection(lastDirection))
                {
                    case "Right":
                        projectiles.Add(new Projectile(player.X + player.Width, (player.Y + player.Height / 2) - 5, lastDirection));
                        break;
                    case "Left":
                        projectiles.Add(new Projectile(player.X - 20, (player.Y + player.Height / 2) - 5, lastDirection));
                        break;
                    case "Up":
                        projectiles.Add(new Projectile(player.X + player.Width / 2, player.Y + player.Height / 2, lastDirection));
                        break;
                    case "Down":
                        projectiles.Add(new Projectile(player.X + player.Width / 2, player.Y + player.Height / 2, lastDirection));
                        break;
                    default:
                        break;
                }

                //projectiles.Add(new Projectile(player.X + player.Width / 2, player.Y + player.Height / 2, lastDirection));
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

        public static string GetDirection(Vector2 direction)
        {
            if (direction.X == 1)
            {
                return "Right";
            }
            else if (direction.X == -1)
            {
                return "Left";
            }
            else if (direction.Y == 1)
            {
                return "Down";
            }
            else if (direction.Y == -1)
            {
                return "Up";
            }
            else
            {
                return "No direction";
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
