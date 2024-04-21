// Position Component
using Raylib_cs;

public interface IPositionComponent
{
    float X { get; set; }
    float Y { get; set; }
}

public class PositionComponent : IPositionComponent
{
    public float X { get; set; }
    public float Y { get; set; }
}

// Velocity Component
public interface IVelocityComponent
{
    float VelocityX { get; set; }
    float VelocityY { get; set; }
}

public class VelocityComponent : IVelocityComponent
{
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
}

// Render Component
public interface IRenderComponent
{
    void Render();
}

public class SquareRenderComponent : IRenderComponent
{
    public IPositionComponent Position { get; set; }

    public void Render()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 20, 20, Color.Red);
    }
}
