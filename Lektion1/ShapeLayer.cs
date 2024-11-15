using System.Reflection.Metadata;
/// <summary>
/// Class for handling all different shapes on the canvas
/// </summary>
class ShapeLayer
{
    /// <summary>
    /// List of shapes on canvas
    /// </summary>
    private List<IShape> Shapes = new List<IShape>();
    /// <summary>
    /// Index for what shape is currently selected. No shapes? then -1
    /// </summary>
    private int selIndex = -1;
    
    /// <summary>
    /// Add a shape
    /// </summary>
    /// <param name="shape"></param>
    public void Add(IShape shape){
        Shapes.Add(shape);
        selIndex = Shapes.Count - 1;
    }

    public void Render(Canvas can){
        foreach(IShape shape in Shapes){
            
            shape.Draw(can);
        }
    }

    public void PrintInfo(){
        Console.WriteLine("List of current rectangles: \n");
        foreach(IShape shape in Shapes){
            Console.WriteLine(shape.Description);
        }
    }

    public void SelNext(){
        selIndex++;
        if(Shapes.Count < 1)
        {
            selIndex = -1;
        }else {
            selIndex = selIndex % Shapes.Count;
        }
    }

    public void MoveSel(int dy, int dx)
    {
        try
        {
            if(Shapes.Count < 1){
            //Do nothing
            }else{
                Shapes[selIndex].Move(dy,dx);
            }
        }catch(Exception e){
            Console.WriteLine(e + "  @ "+ selIndex);
        }
        
    }
    public void RemSel(){
        if(Shapes.Count > 0){
            Shapes.RemoveAt(selIndex);
            selIndex = (Shapes.Count == 0) ? -1 : --selIndex;
        }
    }

    public void ToTopSel(){
        if(Shapes.Count > 0)
        {
        IShape temp = Shapes[selIndex];

        RemSel();
        Add(temp);
        }
        
    }

}