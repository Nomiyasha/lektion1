namespace Lektion1;

public abstract class Shape : IShape
{
    protected Position Position;
    
    public Shape(Position position){
        this.Position = position;
    }

    public abstract void Draw(Canvas canvas);

    public void Move(int dy, int dx){
        Position.Y += dy;
        Position.X += dx;
    }
}