

namespace UnityUtils.Angles.Metrics
{
  public static class Cardinal
  {
    public enum Point { N, NW, W, SW, S, SE, E, NE }

    /// <summary>
    /// Array com todos os pontos cardinais ordenados sentido anti-horário.
    /// </summary>
    public readonly static Point[] _pointsByIndex = new Point[] { Point.N, Point.NW, Point.W, Point.SW, Point.S, Point.SE, Point.E, Point.NE };

    public static Point GetPointByIndex(int index) => _pointsByIndex[index];
  }
}