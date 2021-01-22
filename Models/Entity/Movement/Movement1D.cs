using UnityUtils.Angles;
using UnityUtils.Metrics;
using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public class Movement1D : MovementBase
  {
    public Cardinal.Point lastDirection;

    public Movement1D(Vector2 pos, float mspeed, Cardinal.Point dir) : base(pos, mspeed)
    {
      direction = dir;
      lastDirection = dir;
    }

    public override void SetDirection(Vector2 inputVector)
    {
      if (inputVector.magnitude > 0)
      {
        direction = Convertion.VectorToCardinal2(inputVector);
        lastDirection = direction;
      }
    }
  }
}