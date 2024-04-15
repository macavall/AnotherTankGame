using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    public class Projectile
    {
        // Constructor for the projectile
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
