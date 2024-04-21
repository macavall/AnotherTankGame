using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;


namespace TankGame
{
    public class PositionComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class MovementComponent
    {
        public float VelocityX { get; set; }
        public float VelocityY { get; set;}
    }

    public class Entity
    {
        public PositionComponent Position { get; set; }
        public MovementComponent Movement { get; set; }
    }

    public class EntityManager
    {
        public List<Entity> Entities { get; private set; } = new List<Entity>();

        public void Update()
        {
            foreach (var entity in Entities)
            {
                if (entity.Position != null && entity.Movement != null)
                {
                    // Update position based on velocity
                    entity.Position.X += entity.Movement.VelocityX;
                    entity.Position.Y += entity.Movement.VelocityY;

                    // Screen wrap-around logic
                    entity.Position.X = (entity.Position.X + 800) % 800;
                    entity.Position.Y = (entity.Position.Y + 450) % 450;
                }
            }
        }

        public void Draw()
        {
            foreach (var entity in Entities)
            {
                if (entity.Position != null)
                {
                    Raylib.DrawRectangle((int)entity.Position.X, (int)entity.Position.Y, 50, 50, Color.RED);
                }
            }
        }
    }
    public partial class Program
    {
        public static void Main(string[] args)
        {
            Raylib.InitWindow(800, 450, "Raylib Component Pattern Example");
            EntityManager manager = new EntityManager();

            // Main square
            var mainSquare = new Entity
            {
                Position = new PositionComponent { X = 100, Y = 100 },
                Movement = new MovementComponent { VelocityX = 2, VelocityY = 2 }
            };
            manager.Entities.Add(mainSquare);

            // Add random squares
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var square = new Entity
                {
                    Position = new PositionComponent { X = random.Next(800), Y = random.Next(450) },
                    Movement = new MovementComponent { VelocityX = (float)random.NextDouble() * 4 - 2, VelocityY = (float)random.NextDouble() * 4 - 2 }
                };
                manager.Entities.Add(square);
            }

            while (!Raylib.WindowShouldClose())
            {
                manager.Update();

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                manager.Draw();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
