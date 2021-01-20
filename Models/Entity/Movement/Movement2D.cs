using UnityUtils.Angles;
using UnityUtils.Metrics;
using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public class Movement2D : MobileEntity
  {
    public Cardinal.Points4 direction;

    public Movement2D(
      Vector2 pos,
      float mspeed,
      Cardinal.Points4 direction,
      MovementState state = MovementState.IDLE
     ) : base(pos, mspeed, state)
    {
      this.direction = direction;
    }

    public override string MovementInfo()
      => $"{state.ToString("F").ToLower()} {direction.ToString().ToLower()} ";

    public override void SetDirection(Vector2 inputVector)
    {

      if (inputVector.magnitude > 0)
      {
        state = MovementState.WALK;
        direction = Convertion.VectorToCardinal4(inputVector);
      }
      else
      {
        state = MovementState.IDLE;
      }
    }
  }
}