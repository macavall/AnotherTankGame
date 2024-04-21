using Raylib_cs;
using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        // Initialization
        const int screenWidth = 800;
        const int screenHeight = 450;
        Raylib.InitWindow(screenWidth, screenHeight, "Raylib Component Pattern Example");
        Raylib.SetTargetFPS(60);

        // Create entity manager
        EntityManager manager = new EntityManager();

        // Create and configure entities
        Entity player = new Entity
        {
            Position = new PositionComponent { X = screenWidth / 2, Y = screenHeight / 2 },
            Velocity = new VelocityComponent { VelocityX = 0, VelocityY = 0 },
            Renderer = new SquareRenderComponent()
        };
        ((SquareRenderComponent)player.Renderer).Position = player.Position; // Link the renderer to the position component
        manager.AddEntity(player);

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            // Update all entities
            manager.Update();

            // Handle Input
            if (Raylib.IsKeyDown(KeyboardKey.Right))
                player.Velocity.VelocityX = 2;
            else if (Raylib.IsKeyDown(KeyboardKey.Left))
                player.Velocity.VelocityX = -2;
            else
                player.Velocity.VelocityX = 0;

            if (Raylib.IsKeyDown(KeyboardKey.Up))
                player.Velocity.VelocityY = -2;
            else if (Raylib.IsKeyDown(KeyboardKey.Down))
                player.Velocity.VelocityY = 2;
            else
                player.Velocity.VelocityY = 0;

            // Drawing
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            manager.Draw();
            Raylib.EndDrawing();
        }

        // De-Initialization
        Raylib.CloseWindow();
    }
}
