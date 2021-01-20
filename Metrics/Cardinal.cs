namespace UnityUtils.Metrics
{
  public static class Cardinal
  {
    public enum Points4 { N, W, S, E }

    public enum Points8 { N, NW, W, SW, S, SE, E, NE }
    // 018 top 345 bot 26 horizontal

    // Array com todos os pontos cardinais em sentido anti-horário
    public readonly static Points4[] points4ByIndex = new Points4[] { Points4.N, Points4.W, Points4.S, Points4.E };
    public readonly static Points8[] points8ByIndex = new Points8[] { Points8.N, Points8.NW, Points8.W, Points8.SW, Points8.S, Points8.SE, Points8.E, Points8.NE };

    public static Points4 Cardinal4ByIndex(int index) => points4ByIndex[index];
    public static Points8 Cardinal8ByIndex(int index) => points8ByIndex[index];
  }
}