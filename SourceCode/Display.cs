class Display
{
    private Array2D<char> _arr;
    public Vector2Int Resolution;

    /// <summary>
    /// draws a line between two points using the slope y-intercept form (y = mx + b)
    /// </summary>
    /// <param name="p1">first point</param>
    /// <param name="p2">second point</param>
    /// <param name="character">character to draw the line with</param>
    public void DrawLine(Vector2Int p1, Vector2Int p2, char character = '▓')
    {
        Vector2Int point1 = p1 - new Vector2Int(1, 1);
        Vector2Int point2 = p2 - new Vector2Int(1, 1);

        //plot points at given positions
        this.PlotPoint(point1, character);
        this.PlotPoint(point2, character);

        //slope of the line
        float m = (float)(point2.y - point1.y) / (float)(point2.x - point1.x);

        //draw vertical line if the slope is infinite/undefined (no change in x)
        if (float.IsInfinity(m))

            for (int y = Math.Min(point1.y, point2.y); y < Math.Max(point1.y, point2.y); y++)
                this.PlotPoint(new Vector2Int(point1.x, y), character);

        else
        {
            float b = (float)point1.y - m * (float)point1.x;

            //plot point at (x, mx + b) or (x, y)
            for (int x = Math.Min(point1.x, point2.x); x < Math.Max(point1.x, point2.x); x++)
                this.PlotPoint(new Vector2Int(x, (int)(m * x + b)), character);

            //plot point at ([y-b] / m, y) or (x, y)
            for (int y = Math.Min(point1.y, point2.y); y < Math.Max(point1.y, point2.y); y++)
                this.PlotPoint(new Vector2Int((int)((y - b) / m), y), character);
        }
    }

    public void DrawLines(List<Vector2Int> coordinates)
    {
        for (int i = 0; i < coordinates.Count<Vector2Int>(); i++)
            if (i % 2 != 0)
                this.DrawLine(coordinates.ElementAt<Vector2Int>(i), coordinates.ElementAt<Vector2Int>(i - 1));
    }

    public void DrawLines(params Vector2Int[] coordinates)
    {
        for (int i = 0; i < coordinates.Length; i++)
            if (i % 2 != 0)
                this.DrawLine(coordinates[i], coordinates[i - 1]);
    }

    public void Clear(char character = '░')
    {
        Console.SetCursorPosition(0, 0);
        
        for (int y = 0; y < this._arr.GetLength(0); y++)
            for (int x = 0; x < this._arr.GetLength(1); x++)
                this.PlotPoint(new Vector2Int(x, y), character);
    }

    public void Print() => Console.WriteLine(this._arr.ToString());

    public void PlotPoint(Vector2Int point, char value)
    {
        try
        {
            this._arr.SetElementAt(point, value);
        }
        catch (IndexOutOfRangeException){}
    }

    public Display(Vector2Int Resolution = default(Vector2Int))
    {
        this._arr = new Array2D<char>(Resolution);
        this.Resolution = Resolution;
    }
}
