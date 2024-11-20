namespace Lektion1;
class CompositeShape : IShape
{
    List<IShape> shapes = new List<IShape>();

    public string Description =>
        $"Black magic";


    public CompositeShape(IShape[] shapes){
        this.shapes = shapes.ToList<IShape>();
    }

    public CompositeShape()
        :this(CreateShapes())
    {   }
    
    private static IShape[] CreateShapes(){
        IShape[] result = [];
        List<IShape> shapes = new List<IShape>();
        bool isCorrectInput = false;

        while(!isCorrectInput){
            int choice = Input.ScrollMenu(["Yes", "No"],"Add another shape?");
        
            switch(choice)
            {
                case 0: //Yes
                shapes.Add(ShapeFactory.ChooseShape());
                break;
                case 1: //No
                result = shapes.ToArray();
                isCorrectInput=true;
                break;
                default:
                isCorrectInput=true;
                break;
            }
        }
        return result;
    }


    public void Add(IShape shape){
        shapes.Add(shape);
    }

    public void Draw(Canvas canvas){
        foreach(IShape shape in shapes){
            shape.Draw(canvas);
        }

    }
    public void Move(int dx, int dy)
    {
        foreach(IShape shape in shapes){
            shape.Move(dx,dy);
        }
    }


}