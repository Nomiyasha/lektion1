using System.Globalization;

namespace Lektion1;

public class Menu{

    private readonly MenuItem[] menuItems;

    public Menu(MenuItem[] menuItems){
        this.menuItems = menuItems;
    }

    public void Display(){
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;

        int cols = 6;
        int rows = (int)Math.Ceiling((double)menuItems.Length/(double)cols);
        
        string toAdvPrint ="";

        for(int i = 0; i < rows; i++){
            
            for (int j = 0; j < cols; j++)
            {
                int index = i * cols + j;
                try{
                    toAdvPrint +=menuItems[index].Print()[0];
                }catch{}
            }
            toAdvPrint += "\n";
            for (int j = 0; j < cols; j++)
            {
                int index = i * cols + j;
                try{
                    toAdvPrint +=menuItems[index].Print()[1];
                }catch{}
                
            }
            toAdvPrint += "\n\n";
        }
        
        Console.WriteLine(toAdvPrint);
    }

    public void Handle(ConsoleKey key, ShapeLayer layer){
        foreach (var item in menuItems)
        item.Handle(key, layer);
    }

}