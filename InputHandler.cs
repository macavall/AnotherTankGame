using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    public partial class Program
    {
        // Draw the game
        public static void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            CheckPlayerBoarder();

            Raylib.DrawRectangleRec(player, Color.Blue);

            // Draw projectiles
            foreach (var projectile in projectiles)
            {
                Raylib.DrawRectangleRec(new Rectangle() { X = projectile.X, Y = projectile.Y, Width = projectile.Width, Height = projectile.Height }, Color.Red);
            }

            Raylib.EndDrawing();
        }


        public static void HandleProjectileInput()
        {
            // Shooting projectiles and event handling for space key
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                switch (GetDirection(lastDirection))
                {
                    case "Right":
                        projectiles.Add(new Projectile(player.X + player.Width, (player.Y + player.Height / 2) - 5, lastDirection));
                        break;
                    case "Left":
                        projectiles.Add(new Projectile(player.X - 20, (player.Y + player.Height / 2) - 5, lastDirection));
                        break;
                    case "Up":
                        projectiles.Add(new Projectile((player.X + player.Width / 2) - 5, player.Y - 20, lastDirection));
                        break;
                    case "Down":
                        projectiles.Add(new Projectile((player.X + player.Width / 2) - 5, player.Y + player.Height, lastDirection));
                        break;
                    default:
                        break;
                }
            }
        }

        public static void HandlePlayerInput()
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
        }

        public static void CheckPlayerBoarder()
        {
            // Draw player
            if (player.X < 0)
            {
                player.X = 0;
            }
            else if (player.X + player.Width > screenWidth)
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
        }
    }
}
