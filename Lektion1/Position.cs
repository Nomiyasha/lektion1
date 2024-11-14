public class Position
{
    public int X {get; set;}
    public int Y {get; set;}

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Position(){
        var other = (Position)In.createShape(this.GetType());
        this.X = other.X;
        this.Y = other.Y;
    }
    
    public Position(Position other)
    {
        X = other.X;
        Y = other.Y;
    }

}