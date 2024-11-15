using System.Collections;
using System.Runtime.CompilerServices;

class Logic
{

    private Canvas canvas = new Canvas(50,15);
    private ShapeLayer shapeLayer = new ShapeLayer();
    public Logic(){
        Run();
    }
    /// <summary>
    /// Main logic of the program.
    /// Updates the canvas and then asks for user input
    /// </summary>
    private void Run(){
        bool isRunning = true;
        while(isRunning){
            canvas.Clear();
            shapeLayer.Render(canvas);
            canvas.Render();
            In.MenuMessage();
            int choice = In.Menu();
            switch (choice){
                case 1://d
                    shapeLayer.SelNext();
                    break;
                case 2://f
                    shapeLayer.RemSel();
                    break;
                case 3://j
                    chooseShape();
                    break;
                case 4://k
                    shapeLayer.ToTopSel();
                    break;
                case 5://left
                    shapeLayer.MoveSel(0,-1);
                    break;
                case 6://right
                    shapeLayer.MoveSel(0,1);
                    break;
                case 7://up
                    shapeLayer.MoveSel(-1,0);
                    break;
                case 8://down
                    shapeLayer.MoveSel(1,0);
                    break;
                case 9://esc
                    isRunning=false;
                    break;
            }
            Console.Clear();
            
        }
    }
    /// <summary>
    /// Choose a shape to create, then create it.
    /// </summary>
    private void chooseShape(){
        int choice = In.chooseShapeMenu();
        switch(choice)
        {
            case 0: //Rectangle
            shapeLayer.Add(new Rectangle());
            break;
            case 1: //Diamond
            shapeLayer.Add(new Diamond());
            break;
            case 2: //Line
            shapeLayer.Add(new Line());
            break;
            default:
            //Esc
            break;
        }
    }
}