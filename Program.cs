using Raylib_cs;
using System;
using System.Numerics;


namespace TankGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 450;
            const int spriteSpeed = 5;

            Raylib_cs.Raylib.InitWindow(screenWidth, screenHeight, "Sprite Movement Example");

            // Load sprite image
            Texture2D spriteUp = Raylib_cs.Raylib.LoadTexture("C:\\Users\\macavall\\Pics\\TankUp.png");
            Texture2D spriteRight = Raylib_cs.Raylib.LoadTexture("C:\\Users\\macavall\\Pics\\TankRight.png");
            Texture2D spriteDown = Raylib_cs.Raylib.LoadTexture("C:\\Users\\macavall\\Pics\\TankDown.png");
            Texture2D spriteLeft = Raylib_cs.Raylib.LoadTexture("C:\\Users\\macavall\\Pics\\TankLeft.png");

            Texture2D sprite = spriteUp;

            // Set sprite position
            Vector2 position = new Vector2(screenWidth / 2 - spriteUp.Width / 2, screenHeight / 2 - spriteUp.Height / 2);

            Raylib_cs.Raylib.SetTargetFPS(60);

            while (!Raylib_cs.Raylib.WindowShouldClose())
            {
                // Move sprite based on arrow keys
                if (Raylib_cs.Raylib.IsKeyDown(KeyboardKey.Right))
                {
                    position.X += spriteSpeed;
                    sprite = spriteRight;
                }
                if (Raylib_cs.Raylib.IsKeyDown(KeyboardKey.Left))
                {
                    position.X -= spriteSpeed;
                    sprite = spriteLeft;
                }
                if (Raylib_cs.Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    position.Y += spriteSpeed;
                    sprite = spriteDown;
                }
                if (Raylib_cs.Raylib.IsKeyDown(KeyboardKey.Up))
                {
                    position.Y -= spriteSpeed;
                    sprite = spriteUp;
                }

                // Draw
                Raylib_cs.Raylib.BeginDrawing();
                Raylib_cs.Raylib.ClearBackground(Color.White);
                Raylib_cs.Raylib.DrawTexture(sprite, (int)position.X, (int)position.Y, Color.White);
                Raylib_cs.Raylib.EndDrawing();
            }

            Raylib_cs.Raylib.UnloadTexture(sprite);
            Raylib_cs.Raylib.CloseWindow();
        }
    }
}
