namespace Lektion1;

public class ExitMI : MenuItem
{
    public ExitMI(ConsoleKey key, string label)
        :base(key,label)
    {   }

    protected override void Execute(ShapeLayer layer)
    {
        Input.ExitMessage();
    }


}