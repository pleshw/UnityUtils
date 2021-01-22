using UnityUtils.Angles;
using UnityUtils.Metrics;
using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public class Movement2D : MovementBase
  {
    /// <summary>
    /// Verdadeiro se a entidade pode realizar movimentos em diagonal
    /// </summary>
    public bool diagonals;

    public Movement2D(Vector2 pos, float mspeed, Cardinal.Point dir, bool diag = true) : base(pos, mspeed)
    {
      diagonals = diag;
      direction = dir;
    }

    public override void SetDirection(Vector2 inputVector)
    {
      if (inputVector.magnitude > 0)
      {
        if (diagonals)
        {
          direction = Convertion.VectorToCardinal8(inputVector);
        }
        else
        {
          direction = Convertion.VectorToCardinal4(inputVector);
        }
      }
    }
  }
}