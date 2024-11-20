namespace Lektion1;

public interface IShape
{
    /// <summary>
    /// Interface for the shapes
    /// </summary>
    void Draw(Canvas canvas);
    void Move(int dx, int dy);
    
}