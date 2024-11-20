namespace Lektion1;
/// <summary>
/// Class used to collect static methods for taking user input.
/// </summary>
public static class Input{
    /// <summary>
    /// ConsoleKeys turned to ints
    /// </summary>
    enum CMD{
        d = (int)ConsoleKey.D,
        f = (int)ConsoleKey.F,
        j = (int)ConsoleKey.J,
        k = (int)ConsoleKey.K,
        h = (int)ConsoleKey.H,
        left = (int)ConsoleKey.LeftArrow,
        right = (int)ConsoleKey.RightArrow,
        up = (int)ConsoleKey.UpArrow,
        down = (int)ConsoleKey.DownArrow,
        esc = (int)ConsoleKey.Escape

    }
    /// <summary>
    /// Simple error message.
    /// </summary>
    public static void ErrorMessage(){
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Invalid input!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void ExitMessage(){
        Console.Clear();
        Console.WriteLine("See you next time!");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Press anything to exit...");
        Console.ReadKey(true);
        Environment.Exit(123);

    }

    /// <summary>
    /// A function for getting input of a certain Type T.
    /// Handles all standard types and the class Position.
    /// </summary>
    /// <typeparam name="T">Type to recieve input for</typeparam>
    /// <param name="query">A question word</param>
    /// <returns>User entered value of type T</returns>
    public static T GetInputType<T>(string query)
    {
        T result = default;
        
        bool isCorrectInput = false;
        while(!isCorrectInput){
            try{
                if(typeof(T) == typeof(Position)){
                        result = (T)(Object)new Position();
                }else if(typeof(T) == typeof(Symbol)){
                    result = (T)(Object)new Symbol();
                }
                else if(typeof(T) == typeof(ConsoleColor)){
                    bool isNumeric = true;
                    do
                    {
                    Console.WriteLine("Enter a "+ query + ": (Example: \"Red\" or \"Blue\".) ");
                    string input = Console.ReadLine();
                    isNumeric = input.All(Char.IsDigit);
                    result = (T)Enum.Parse(typeof(ConsoleColor), input, true);
                    if(isNumeric){ErrorMessage();} 
                    }while(isNumeric);
                    
                }
                else{
                Console.WriteLine("Enter a "+ query + ": ");
                string input = Console.ReadLine();
                result = (T)Convert.ChangeType(input, typeof(T));                 
                }
                isCorrectInput=true;
                
            }catch{
                ErrorMessage();
            }
        }
        Console.Clear();
        return result;
    }
    
    //A menu for choosing a shape to create
    public static int ScrollMenu(string[] choices, string message)
    {
        
        bool isCorrectInput = false;

        int selIndex = 0;
        while(!isCorrectInput)
        {   
            Console.Clear();
            try
            {
                Console.WriteLine($"{message}: (press j to confirm choice)");
            for(int i = 0; i < choices.Length; i++){
                if(selIndex == i){
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(choices[i]);
                    Console.ResetColor();
                }
                else{
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" " + choices[i]);
                    Console.ResetColor();
                }
            }
            CMD input = (CMD)Console.ReadKey(true).Key;
              
            switch(input){
                case CMD.down:
                    selIndex++;
                    selIndex = selIndex%choices.Length;
                    break;
                case CMD.up:
                    selIndex--;
                    if(selIndex < 0){
                        selIndex = choices.Length -1;
                    }
                    break;
                case CMD.esc:
                    return -1;
                case CMD.j:
                    isCorrectInput = true;
                    break;
                default:
                    ErrorMessage();
                    break;
            }
            }catch{
                ErrorMessage();
            }
            
            
        }
        Console.Clear();
        return selIndex;
    }  
    
}