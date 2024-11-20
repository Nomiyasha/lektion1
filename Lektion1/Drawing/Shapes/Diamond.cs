namespace Lektion1;

public class Diamond : Shape
{
    private readonly Symbol symbol;
    private readonly int  size;
    private int calcSize =>
        this.size/2;

    public Diamond(Symbol symbol, int size, Position position)
        :base(position)
    {
        this.symbol = symbol;
        this.size = size;
    }

    public Diamond()
    :this(Input.GetInputType<Symbol>("symbol"),
        Input.GetInputType<int>("size"),
        Input.GetInputType<Position>("position"))
    {    }

    public override void Draw(Canvas canvas){
        D(canvas,calcSize+1,Position);
    }
    private void D(Canvas canvas, int size, Position pos){
        if (size>0){
        D(canvas, size-1, new Position(pos.X-1,pos.Y));
        D(canvas, size-1, new Position(pos.X+1,pos.Y));
        }
        
        for (int i= 0; i<size; i ++){
            canvas.Draw(symbol,new Position(pos.X,pos.Y+i));
        }
        for (int i= size; i>0; i --){
            canvas.Draw(symbol,new Position(pos.X,pos.Y-i+1));
        }
    }
}