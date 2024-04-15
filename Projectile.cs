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
        private static void UpdateProjectiles()
        {
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
    }


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
        public float Width { get; set; }
        public float Height { get; set; }

        // Define the projectile position
        public float X { get; set; }
        public float Y { get; set; }

        // Define the projectile speed
        public float projectileSpeed = 200.0f;
    }
}
