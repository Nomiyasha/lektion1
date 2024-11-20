namespace Lektion1;

public class MoveMI : MenuItem
{
    private int dx;
    private int dy;
    public MoveMI(ConsoleKey key, string label)
        :base(key,label)
    {
        this.dy = key switch{
            ConsoleKey.UpArrow => -1,
            ConsoleKey.DownArrow => 1,
            _ => 0
        };
        this.dx = key switch{
            ConsoleKey.LeftArrow => -1,
            ConsoleKey.RightArrow => 1,
            _ => 0
        };
    }

    protected override void Execute(ShapeLayer layer)
    {
        layer.MoveSelectedShape(dy,dx);
    }


}