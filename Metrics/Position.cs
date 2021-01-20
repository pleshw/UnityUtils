using System;

namespace UnityUtils.Metrics
{

  public static class Position
  {

    // Posições em sentido anti-horário
    public enum Horizontal { NONE, LEFT, RIGHT }

    public enum Vertical { NONE, TOP, BOTTOM }

    public enum Position2D { TOP, LEFT, BOTTOM, RIGHT }

    public static readonly Position2D[] positionsByIndex = new Position2D[] { Position2D.TOP, Position2D.LEFT, Position2D.BOTTOM, Position2D.RIGHT };

    public static Position2D PositionByIndex(int index) => positionsByIndex[index];

    public struct Direction2D
    {
      public Horizontal horizontal;
      public Vertical vertical;

      public override string ToString()
      {
        return $"{(vertical.ToString("F"))} {(horizontal.ToString("F"))}";
      }
    }

    public static readonly Direction2D defaultDirection = new Position.Direction2D
    {
      horizontal = Position.Horizontal.NONE,
      vertical = Position.Vertical.BOTTOM
    };
  }
}