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
    }
}
