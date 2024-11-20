namespace Lektion1;

public class Symbol{
    private char Ch {get; set;}
    private ConsoleColor Color {get; set;}

    public Symbol(char ch, ConsoleColor color){
        Ch = ch;
        Color = color;
    }
    public Symbol(char ch)
    :this(ch, default)
    {    }

    public Symbol()
    :this(Input.GetInputType<char>("symbol"),
        Input.GetInputType<ConsoleColor>("color"))
    {    }

    public void Draw(){
        Console.ForegroundColor = Color;
        Console.Write($"{Ch}");
        Console.ResetColor();
    }
}