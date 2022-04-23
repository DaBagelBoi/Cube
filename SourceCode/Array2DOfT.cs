class Array2D<T>
{
  //built-in 2D array to store data about this new 2D array class
  private T[,] arr;

  public T GetElementAt(Vector2Int coordinate) => this.arr[coordinate.y, coordinate.x];

  public void SetElementAt(Vector2Int coordinate, T value) => this.arr[coordinate.y, coordinate.x] = value;

  public int GetLength(int dimension) => this.arr.GetLength(dimension);

  public Array2D(Vector2Int Dimensions = default (Vector2Int)) => this.arr = new T[Dimensions.y, Dimensions.x];

  public override string ToString()
  {
    string str = "";
    for (int y = 0; y < this.arr.GetLength(0); y++)
    {
      for (int x = 0; x < this.arr.GetLength(1); x++)
        #pragma warning disable CS8602
        str = str + this.arr[y, x].ToString() + this.arr[y, x].ToString();
        
      str += "\n";
    }
    return str;
  }
}
