namespace Lektion1;

public class AddMI : MenuItem
{
    public AddMI(ConsoleKey key, string label)
        :base(key,label)
    {   }

    protected override void Execute(ShapeLayer layer)
    {
        layer.Add(ShapeFactory.ChooseShape());
    }

}