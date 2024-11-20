namespace Lektion1;

public class ToFrontMI : MenuItem
{
    public ToFrontMI(ConsoleKey key, string label)
        :base(key,label)
    {   }

    protected override void Execute(ShapeLayer layer)
    {
        layer.ToFrontSelectedShape();
    }

}