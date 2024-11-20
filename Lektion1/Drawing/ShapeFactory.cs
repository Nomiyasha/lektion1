namespace Lektion1;

public static class ShapeFactory{
    public static IShape CreateShape(string shapeType){
        return shapeType.ToLower() switch {
            "rectangle" => new Rectangle(),
            "diamond" => new Diamond(),
            "composite shape" => new CompositeShape(),
            _ => throw new ArgumentException("Invalid shape chosen")
        };
    }

    public static IShape ChooseShape()
    {
        string[] shapeChoices = {"Rectangle", "Diamond","Composite Shape"};
        int choice = Input.ScrollMenu(shapeChoices, "Choose a shape");
        return ShapeFactory.CreateShape(shapeChoices[choice]);
    }
}