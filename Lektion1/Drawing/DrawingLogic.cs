using System.Net.Http.Headers;

namespace Lektion1;

class DrawingLogic
{

    private Canvas canvas = new Canvas(50,15);
    private ShapeLayer shapeLayer = new ShapeLayer();
    private Menu menu = new Menu([
        new SwitchMI(ConsoleKey.D,"Next"),
        new AddMI(ConsoleKey.F, "Add"),
        new DeleteMI(ConsoleKey.J,"Del"),
        new ToFrontMI(ConsoleKey.K,"Front"),
        new MoveMI(ConsoleKey.UpArrow,"Up"),
        new MoveMI(ConsoleKey.DownArrow,"Down"),
        new MoveMI(ConsoleKey.LeftArrow,"Left"),
        new MoveMI(ConsoleKey.RightArrow,"Right"),
        new ExitMI(ConsoleKey.Escape, "Exit")
    ]);

    public DrawingLogic(){
        Run();
    }
    /// <summary>
    /// Main logic of the program.
    /// Updates the canvas and then asks for user input
    /// </summary>
    private void Run(){
        bool isRunning = true;
        while(isRunning){
            Console.CursorVisible = false;
            canvas.Clear();
            shapeLayer.Render(canvas);
            canvas.Render();
            menu.Display();
            menu.Handle(Console.ReadKey(true).Key,shapeLayer);
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = true;
            
        }
    }
    
    
    
}