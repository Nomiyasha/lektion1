public class Diamond : IShape
{
    private readonly char  symbol;
    private readonly int  size;
    private Position pos;

    private int calcSize =>
        this.size/2;
    public string Description =>
        $"Diamond using symbol '{this.symbol}' with size {this.size} at ({this.pos.X}, {this.pos.Y}).";

    public Diamond(char symbol, int size, Position pos){
        this.symbol = symbol;
        this.size = size;
        this.pos = pos;
    }

    public Diamond(){
        var other = (Diamond)In.createShape(this.GetType());
        this.symbol = other.symbol;
        this.size = other.size;
        this.pos = other.pos;
    }

    public void Draw(Canvas canvas){
        D(canvas,this.calcSize+1,this.pos);
        canvas.Draw('§',pos);
    }
    private void D(Canvas canvas, int size, Position pos){
        if (size>0){
        D(canvas, size-1, new Position(pos.X-1,pos.Y));
        D(canvas, size-1, new Position(pos.X+1,pos.Y));
        }
        
        for (int i= 0; i<size; i ++){
            canvas.Draw(this.symbol,new Position(pos.X,pos.Y+i));
        }
        for (int i= size; i>0; i --){
            canvas.Draw(this.symbol,new Position(pos.X,pos.Y-i+1));
        }
    }
    public void Move(int dx, int dy){
        pos = new Position(pos.X+dx, pos.Y +dy);
    }
}