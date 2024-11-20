namespace Lektion1;
public class Position
{
    public int X {get; set;}
    public int Y {get; set;}

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Position()
    :this(Input.GetInputType<int>("X position"),
        Input.GetInputType<int>("Y position"))
    {    }
    
    public Position(Position other)
    :this(other.X,other.Y)
    {    }

}