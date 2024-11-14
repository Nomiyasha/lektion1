using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
/// <summary>
/// Class used to collect static methods for taking user input.
/// </summary>
class In{
    /// <summary>
    /// ConsoleKeys turned to ints
    /// </summary>
    enum CMD{
        d = (int)ConsoleKey.D,
        f = (int)ConsoleKey.F,
        j = (int)ConsoleKey.J,
        k = (int)ConsoleKey.K,
        left = (int)ConsoleKey.LeftArrow,
        right = (int)ConsoleKey.RightArrow,
        up = (int)ConsoleKey.UpArrow,
        down = (int)ConsoleKey.DownArrow,
        esc = (int)ConsoleKey.Escape

    }
    /// <summary>
    /// Function for displaying the main menu and handling user input with regards to it.
    /// </summary>
    /// <returns>A number based of the users choice.</returns>
    public static int Menu(){
        bool isCorrectInput = false;
        int result = 0;
        while(!isCorrectInput){

            CMD input = (CMD)Console.ReadKey().Key;
            try{
            Console.SetCursorPosition(Console.CursorLeft-1,Console.CursorTop);
            }catch{
                //do nothing
            }
            switch(input)
            {
                case CMD.d:
                    result = 1;
                    isCorrectInput = true;
                    break;
                case CMD.f:
                    result = 2;
                    isCorrectInput = true;
                    break;
                case CMD.j:
                    result = 3;
                    isCorrectInput = true;
                    break;
                case CMD.k:
                    result = 4;
                    isCorrectInput = true;
                    break;
                case CMD.left:
                    result=5;
                    isCorrectInput = true;
                    break;
                case CMD.right:
                    result=6;
                    isCorrectInput = true;
                    break;
                case CMD.up:
                    result=7;
                    isCorrectInput = true;
                    break;
                case CMD.down:
                    result=8;
                    isCorrectInput = true;
                    break;
                case CMD.esc:
                    result=9;
                    isCorrectInput = true;
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
        return result;
    }
    /// <summary>
    /// Simple error message.
    /// </summary>
    public static void ErrorMessage(){
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Invalid input!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Displaying the main menu
    /// </summary>
    public static void MenuMessage()
    {
        Console.WriteLine("Commands:");
        foreach (string word in new string[]{"d","f","j","k","left","right","up","down","esc"}){
            Console.Write(" <");
            Console.Write(word);
            Console.Write("> ");
        }
        Console.WriteLine("\nNext  Rem  Add Front");
    }
    /// <summary>
    /// A function for getting input of a certain Type T.
    /// Handles all standard types and the class Position.
    /// </summary>
    /// <typeparam name="T">Type to recieve input for</typeparam>
    /// <param name="query">A question word</param>
    /// <returns>User entered value of type T</returns>
    public static T GetInput<T>(string query)
    {
        T result = default;
        
        bool isCorrectInput = false;
        while(!isCorrectInput){
            try{
                if(typeof(T) == typeof(Position)){
                        var other = (Position)In.createShape(typeof(Position));
                        result = (T)(Object)new Position(other);
                }else{
                Console.WriteLine("Enter a "+ query + ": ");
                string input = Console.ReadLine();
                result = (T)Convert.ChangeType(input, typeof(T));                 
                }
                isCorrectInput=true;
            }catch(Exception e){
                //Console.WriteLine(e);
                ErrorMessage();
            }
        }
        return result;
    }
    /// <summary>
    /// A complicated class for creating a type.
    /// Used in the constructors of the shapes.
    /// Utilizes getInput from above to dynamically ask the user for input depending on
    /// what object is to be created.
    /// 
    /// Uses a bunch of black magic to get around runtime vs compiletime Type rules.
    /// Very unsure of how this looks on the heap/stack side. #BringBackPointers
    /// 
    /// Note: not sure if this should be in this class.
    /// Note: not sure if it is a good implementation at all. Uses some deprecated stuff.
    /// </summary>
    /// <param name="shapeType">Type to create</param>
    /// <returns>An object containing the fields of shapeType. 
    /// Cast to shapeType before using to assign.
    /// Example: var other = (Rectangle)In.createShape(Rectangle);</returns>
    public static object createShape(Type shapeType){

        //create a dummy object of type/class shapeType
        var shape = FormatterServices.GetUninitializedObject(shapeType);
        //get the fields of the type/class shapeType
        FieldInfo[] fields = shapeType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //loop through the fields
        for(int i = 0; i < fields.Length; i++)
        {
            //For compact code
            Type fieldType = fields[i].FieldType;
            //Use reflection to create a "shadow"/"dummy" of the GetInput function
            var getInputMethod =typeof(In).GetMethod("GetInput", new[] {typeof(string)});
            //make another shadow/dummything from the above black magic
            var genericMethod = getInputMethod.MakeGenericMethod(fieldType);
            //initialize a object to a value
            object value;
            //Do this diffrently depending on if it is a standard type or of type Position 
            if(shapeType == typeof(Position)){
                value = (i == 0) ? genericMethod.Invoke(null, new object[]{"X"}) : genericMethod.Invoke(null, new object[]{"Y"});
            }else{
                //give the object a value by calling the vodoo doll of GetInput
            value = genericMethod.Invoke(null, new object[]{fields[i].Name});
            }
            //set the value to the field of our dummy object shape that we created in the beginning
            fields[i].SetValue(shape, value);
        }
        //send back the result of going through all the properties and giving them values from user input
        return shape;
    }

    //A menu for choosing a shape to create
    public static int chooseShapeMenu()
    {
        bool isCorrectInput = false;

        int selIndex = 0;
        string[] choices = {"Rectangle", "Diamond","Line (Broken)"}; 
        while(!isCorrectInput)
        {   
            Console.Clear();
            try
            {
                Console.WriteLine("Choose a shape to create: (press f to confirm choice)");
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
            CMD input = (CMD)Console.ReadKey().Key;
            try{
                Console.SetCursorPosition(Console.CursorLeft-1,Console.CursorTop);
            }catch{
                //do nothing
            }        
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
                break;
                case CMD.f:
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
        return selIndex;
    }

    //Old createShape
    /*
    public Rectangle createShape(){
        bool isCorrectInput = false;

        Rectangle rectangle = new Rectangle('E',1,1, new Position(0,0));
        
        Type rectangleClass = typeof(Rectangle);
        FieldInfo[] fields = rectangleClass.GetFields();

        while(!isCorrectInput){
            try
            {
                foreach(FieldInfo field in fields){
                    if(field.FieldType == typeof(Position)){
                        Console.Write("Position: (X Y) ");
                        string input = Console.ReadLine();
                        int X = int.Parse(input.Split(' ')[0]);
                        int Y = int.Parse(input.Split(' ')[1]);
                        rectangle.pos = new Position(X,Y);
                    }else{
                        Console.Write(field.Name + ": ");
                        string input = Console.ReadLine();
                        Console.WriteLine(field.FieldType);
                        field.SetValue(rectangle, Convert.ChangeType(input, field.FieldType));
                    }
                }
                isCorrectInput = true;
            }catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input!" + e.Message + e.Source);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        return rectangle;
    }
    */
    

}