public class Line
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

    public void Draw(Canvas canvas)
    {
        Position cur = new Position(start.Y, start.X); // Start at the starting position

        // Calculate differences and steps
        int dx = Math.Abs(end.X - start.X);
        int dy = Math.Abs(end.Y - start.Y);
        int sx = (start.X < end.X) ? 1 : -1; // Step in X direction
        int sy = (start.Y < end.Y) ? 1 : -1; // Step in Y direction
        int err = dx - dy; // Error term

        // Loop until the current position reaches the end position
        while (cur.X != end.X || cur.Y != end.Y)
        {
            // Draw the current position
            canvas.Draw(symbol, cur);

            // Calculate the error term for the next step
            int e2 = 2 * err;

            // If the error is greater than or equal to zero, step in X direction
            if (e2 > -dy)
            {
                err -= dy;
                cur.X += sx;
            }

            // If the error is less than or equal to zero, step in Y direction
            if (e2 < dx)
            {
                err += dx;
                cur.Y += sy;
            }
        }

        // Finally, draw the end position
        canvas.Draw(symbol, cur);
    }
}