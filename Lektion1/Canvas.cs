public class Canvas
{
    private readonly char[,] grid;
    public int Height{get;}
    public int Width{get;}

    public Canvas(int width, int height)
    {
        Height = height;
        Width = width;

        grid = new char[Width, Height];
        Clear();
    }

    public void Clear(){
        for(int i = 0; i < Width; i++){
            for(int j = 0; j < Height; j++){
                grid[i,j] = ' ';
            }
        }
    }
    public void Render(){
        for(int i = 0; i < Width+2; i++){
            for(int j = 0; j < Height+2; j++){
                if(i == 0 || i == Width+1){
                    Console.Write("-");
                }
                else
                {
                    if(j == 0 || j == Height+1)
                    {
                    Console.Write("|");
                    
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