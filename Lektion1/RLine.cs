using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class RLine{

    //Old attempt!
    
    private char _symbol;
    private Position _start;
    private Position _end;


    public RLine(char symbol, Position start, Position end){
        _symbol = symbol;
        _start = start;
        _end = end;
    }


    public void Draw(Canvas canvas){
        if(_start.Y < _end.Y && _start.X < _end.Y){
            Position temp = new Position(_end);
            _end = new Position(_start);
            _start = new Position(temp);
            Console.WriteLine("a");
        }

        //Y=kx+m

        int dy = _start.Y - _end.Y;
        int dx= _start.X - _end.X;

        int k = dy/dx;

        int m = k+_start.X-_start.Y;

        while(_start.X <= _end.X && _start.Y <= _end.Y){
            int diry = 0;
            int dirx = 0;

            if(_start.Y<_end.Y){
                diry = 1;
             }else if(_start.Y >_end.Y){
                diry =-1;
            }
            if(_start.X<_end.X){
                dirx = 1;
            }else if(_start.X >_end.X){
                dirx =-1;
            }




            for(int i = 0; i < Math.Abs(k); i++){
                canvas.Draw(_symbol,_start);
                Console.WriteLine(_start.X + " " + _start.Y);

                _start.Y += diry;
                if(_start.Y == _end.Y){
                    break;
                }
            }
             _start.X +=dirx;


        }
    }
}