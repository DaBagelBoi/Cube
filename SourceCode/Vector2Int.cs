struct Vector2Int
{
  public int x;
  public int y;

  public Vector2Int(int x, int y)
  {
    this.x = x;
    this.y = y;
  }

  public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);

  public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);

  public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.x * b, a.y * b);
}
