namespace Lektion1;

public class DeleteMI : MenuItem
{
    public DeleteMI(ConsoleKey key, string label)
        :base(key,label)
    {   }

    protected override void Execute(ShapeLayer layer)
    {
        layer.DeleteSelectedShape();
    }


}