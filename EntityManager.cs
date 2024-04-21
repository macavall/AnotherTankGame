using System.Collections.Generic;

public class Entity
{
    public IPositionComponent Position { get; set; }
    public IVelocityComponent Velocity { get; set; }
    public IRenderComponent Renderer { get; set; }

    public void Update()
    {
        Position.X += Velocity.VelocityX;
        Position.Y += Velocity.VelocityY;
    }

    public void Draw()
    {
        Renderer.Render();
    }
}

public class EntityManager
{
    private List<Entity> entities = new List<Entity>();

    public void AddEntity(Entity entity)
    {
        entities.Add(entity);
    }

    public void Update()
    {
        foreach (var entity in entities)
        {
            entity.Update();
        }
    }

    public void Draw()
    {
        foreach (var entity in entities)
        {
            entity.Draw();
        }
    }
}
