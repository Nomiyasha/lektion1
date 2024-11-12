using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Rectangle
{
    private readonly char  symbol;
    private readonly int  width;
    private readonly int height;
    private Position pos;

    public string Description =>
        $"Rectangle using symbol '{symbol}' with size {width}x{height} at ({pos.X}, {pos.Y}).";

    public Rectangle(char symbol, int width, int height, Position pos){
        this.symbol = symbol;
        this.width = width;
        this.height = height;
        this.pos = pos;
    }

    public void Draw(Canvas canvas){
        for(int i =  pos.X; i < pos.X+width; i++){
            for(int j =  pos.Y; j < pos.Y+height; j++){
                
                canvas.Draw(symbol,new Position(i,j));
            }
        }
    }

    public void Move(int dx, int dy){
        pos.X += dx;
        pos.Y += dy;
    }
}