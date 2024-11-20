namespace Lektion1;
/// <summary>
/// Class for a rectangle.
/// </summary>
public class Rectangle : Shape
{
    private readonly Symbol  symbol;
    private readonly int  width;
    private readonly int height;

    public Rectangle(Symbol symbol, int width, int height, Position position)
        :base(position)
    {
        this.symbol = symbol;
        this.width = width;
        this.height = height;
    }
    public Rectangle()
    :this(Input.GetInputType<Symbol>("symbol"),
        Input.GetInputType<int>("width"),
        Input.GetInputType<int>("height"),
        Input.GetInputType<Position>("position"))
    {    }

    public override void Draw(Canvas canvas){
        for(int i =  Position.Y; i < Position.Y+height; i++){
            for(int j =  Position.X; j < Position.X+width; j++){
                
                canvas.Draw(symbol,new Position(j,i));
            }
        }
    }

}