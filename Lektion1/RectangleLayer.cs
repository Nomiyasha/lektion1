using System.Reflection.Metadata;

class RectangleLayer
{
    private List<Rectangle> Rectangles = new List<Rectangle>();

    private int selIndex = -1;

    public void Add(Rectangle rect){
        Rectangles.Add(rect);
        selIndex = Rectangles.Count - 1;
    }

    public void Render(Canvas can){
        foreach(Rectangle rect in Rectangles){
            rect.Draw(can);
        }
    }

    public void PrintInfo(){
        Console.WriteLine("List of current rectangles: \n");
        foreach(Rectangle rect in Rectangles){
            Console.WriteLine(rect.Description);
        }
    }

    public void SelNext(){
        selIndex++;
        if(Rectangles.Count < 1)
        {
            selIndex = -1;
        }else if(selIndex % Rectangles.Count == 0){
            selIndex = 0;
        }
    }

    public void MoveSel(int dx, int dy)
    {
        if(Rectangles.Count < 1){
            //Do nothing
        }else{
            Rectangles[selIndex].Move(dx,dy);
        }
    }
    public void RemSel(){
        Rectangles.RemoveAt(selIndex);
        selIndex = (Rectangles.Count == 0) ? -1 : --selIndex;
    }

    public void ToTopSel(){
        Rectangle temp = Rectangles[selIndex];

        RemSel();
        Rectangles.Add(temp);
    }

}