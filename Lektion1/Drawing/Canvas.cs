namespace Lektion1;

public class Canvas
{
    private readonly Symbol[,] grid;
    public int Height{get;}
    public int Width{get;}
    private Symbol Border
        => new Symbol('#',ConsoleColor.DarkBlue);

    public Canvas(int width, int height)
    {
        Height = height;
        Width = width;
        grid = new Symbol[Height, Width];

        Clear(); //Initialize Canvas
    }

    public void Clear(){
        for(int i = 0; i < Height; i++){
            for(int j = 0; j < Width; j++){
                grid[i,j] = new Symbol(' ');
            }
        }
    }

    public void Render(){
        for(int i = 0; i < Height+2; i++){
            for(int j = 0; j < Width+2; j++){
                if(j == 0 || j == Width+1){
                    Border.Draw();
                }
                else
                {
                    if(i == 0 || i == Height+1)
                    {
                    Border.Draw();
                    
                    }else{
                    grid[i-1,j-1].Draw();  
                    }
                }
            }
            Console.WriteLine();
        }
    }

    public void Draw(Symbol symbol, Position pos){
        try
        {
            grid[pos.X,pos.Y] = symbol;
        }catch{
            //Do nothing
        }
    }
}