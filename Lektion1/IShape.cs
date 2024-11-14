interface IShape
{
    /// <summary>
    /// interface for the shape Type
    /// </summary>
    public string Description{get;}
    public void Draw(Canvas canvas);
    public void Move(int dy, int dx);
}