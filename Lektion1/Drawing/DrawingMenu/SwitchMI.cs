namespace Lektion1;

public class SwitchMI : MenuItem
{
    public SwitchMI(ConsoleKey key, string label)
        :base(key,label)
    {   }

    protected override void Execute(ShapeLayer layer)
    {
        layer.SelectNextShape();
    }

}