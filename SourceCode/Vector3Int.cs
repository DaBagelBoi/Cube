struct Vector3Int
{
  public int x;
  public int y;
  public int z;

  public Vector3Int(int x, int y, int z)
  {
    this.x = x;
    this.y = y;
    this.z = z;
  }

  public static Vector3Int operator +(Vector3Int a, Vector3Int b) => new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);

  public static Vector3Int operator -(Vector3Int a, Vector3Int b) => new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);

  public static Vector3Int operator *(Vector3Int a, int b) => new Vector3Int(a.x * b, a.y * b, a.z * b);
}
