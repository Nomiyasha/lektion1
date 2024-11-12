public class Diamond
{
    private readonly char  symbol;
    private readonly int  size;
    private Position pos;

    public string Description =>
        $"Diamond using symbol '{this.symbol}' with size {this.size} at ({this.pos.X}, {this.pos.Y}).";

    public Diamond(char symbol, int size, Position pos){
        this.symbol = symbol;
        this.size = size;
        this.pos = pos;
    }

    public void Draw(Canvas canvas){
        D(canvas,this.size,this.pos);
    }
    private void D(Canvas canvas, int size, Position pos){
        if (size>0){
        D(canvas, (int)Math.Ceiling((double)size/2)-1, new Position(pos.Y-1,pos.X));
        D(canvas, (int)Math.Ceiling((double)size/2)-1, new Position(pos.Y+1,pos.X));
        }
        
        for (int i= 0; i<(int)Math.Ceiling((double)size/2); i ++){
            canvas.Draw(this.symbol,new Position(pos.X,pos.Y+i));
        }
        for (int i= (int)Math.Ceiling((double)size/2); i>0; i --){
            canvas.Draw(this.symbol,new Position(pos.X,pos.Y-i+1));
        }
    }
}