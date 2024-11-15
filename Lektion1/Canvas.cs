public class Canvas
{
    private readonly char[,] grid;
    public int Height{get;}
    public int Width{get;}

    public Canvas(int width, int height)
    {
        Height = height;
        Width = width;

        grid = new char[Height, Width];
        Clear();
    }

    public void Clear(){
        for(int i = 0; i < Height; i++){
            for(int j = 0; j < Width; j++){
                grid[i,j] = ' ';
            }
        }
    }
    public void Render(){
        for(int i = 0; i < Height+2; i++){
            for(int j = 0; j < Width+2; j++){
                if(j == 0 || j == Width+1){
                    Console.Write("|");
                }
                else
                {
                    if(i == 0 || i == Height+1)
                    {
                    Console.Write("-");
                    
                    }else{
                    Console.Write(grid[i-1,j-1].ToString());  
                    }
                }
            }
            Console.WriteLine();
        }
    }

    public void Draw(char symbol, Position pos){
        try
        {
            grid[pos.X,pos.Y] = symbol;
        }catch{
            //Do nothing
        }
        
    }
}