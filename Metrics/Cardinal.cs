namespace UnityUtils.Metrics
{
  public static class Cardinal
  {

    public enum Point { N, NW, W, SW, S, SE, E, NE }

    // Array com todos os pontos cardinais em sentido anti-horário
    public readonly static Point[] points2 = new Point[] { Point.W, Point.E };
    public readonly static Point[] points4 = new Point[] { Point.N, Point.W, Point.S, Point.E };
    public readonly static Point[] points8 = new Point[] { Point.N, Point.NW, Point.W, Point.SW, Point.S, Point.SE, Point.E, Point.NE };
    public readonly static string[] positionsInCardinalOrder = new string[] { "top", "top left", "left", "bottom left", "bottom", "bottom right", "right", "top right" };

    public static Point Cardinal2ByIndex(int index) => points2[index];
    public static Point Cardinal4ByIndex(int index) => points4[index];
    public static Point Cardinal8ByIndex(int index) => points8[index];
  }
}