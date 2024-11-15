using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
/// <summary>
/// Class for a rectangle.
/// </summary>
public class Rectangle : IShape
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
    public Rectangle(){
        var other = (Rectangle)In.createShape(this.GetType());
        this.symbol = other.symbol;
        this.width = other.width;
        this.height = other.height;
        this.pos = other.pos;
    }

    public void Draw(Canvas canvas){
        for(int i =  pos.Y; i < pos.Y+height; i++){
            for(int j =  pos.X; j < pos.X+width; j++){
                
                canvas.Draw(symbol,new Position(i,j));
            }
        }
    }

    public void Move(int dy, int dx){
        pos.Y += dy;
        pos.X += dx;
    }

}