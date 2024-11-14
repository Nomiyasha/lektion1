/// <summary>
/// Class for a line drawn using Bresenham's formula for lines
/// </summary>
public class Line:IShape
{
    //ChatGPT pga tilt.
    //Bresenhams linje
    //Jag var ganska nära ändå! Yippie

    private char symbol;
    private Position start;
    private Position end;

     public string Description =>
        $"Diamond using symbol '{this.symbol}' from ({this.start.X},{this.start.Y} to ({this.end.X},{this.end.Y})).";


    public Line(char symbol, Position start, Position end)
    {
        this.symbol = symbol;
        this.start = start;
        this.end = end;
    }
    public Line(){
        var other = (Line)In.createShape(this.GetType());
        this.symbol = other.symbol;
        this.start = other.start;
        this.end = other.end;
    }
    /// <summary>
    /// Somewhat broken implementation of Bresenham's line.
    /// Has a start position and an end position. 
    /// </summary>
    /// <param name="canvas">Canvas to draw on</param>
    public void Draw(Canvas canvas)
    {
        Position cur = new Position(start.Y, start.X); // Start at the starting position

        // Calculate differences and steps
        int dix = Math.Abs(end.X - start.X);
        int diy = Math.Abs(end.Y - start.Y);
        int sx = (start.X < end.X) ? 1 : -1; // Step in X direction
        int sy = (start.Y < end.Y) ? 1 : -1; // Step in Y direction
        int err = dix - diy; // Error term

        // Loop until the current position reaches the end position
        int tries = 0;
        while (cur.X != end.X || cur.Y != end.Y)
        {
            tries++;
            if (tries == 100){break;}
            // Draw the current position
            canvas.Draw(symbol, cur);

            // Calculate the error term for the next step
            int e2 = 2 * err;

            // If the error is greater than or equal to zero, step in X direction
            if (e2 > -diy)
            {
                err -= diy;
                cur.X += sx;
            }

            // If the error is less than or equal to zero, step in Y direction
            if (e2 < dix)
            {
                err += dix;
                cur.Y += sy;
            }
        }

        // Finally, draw the end position
        canvas.Draw('§', start);
    }
    /// <summary>
    /// Utterly broken move function. 
    /// Only moves the start position of the line.
    /// </summary>
    /// <param name="dx">steps on x axis</param>
    /// <param name="dy">steps on y axis</param>
    public void Move(int dx, int dy){
        
        this.start = new Position(start.X+dx, start.Y+dy);
        //this.end = new Position(end.X+dx,end.Y+dy);
        
    }
}