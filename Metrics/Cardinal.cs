namespace UnityUtils.Metrics
{
  public static class Cardinal
  {
    public enum Point { N, NW, W, SW, S, SE, E, NE }

    // Array com todos os pontos cardinais em sentido anti-horário
    public readonly static Point[] _pointsByIndex = new Point[] { Point.N, Point.NW, Point.W, Point.SW, Point.S, Point.SE, Point.E, Point.NE };

    public static Point GetPointByIndex(int index) => _pointsByIndex[index];
  }
}