using UnityUtils.Angles;
using UnityUtils.Metrics;
using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public class Sprite1DMovement2D : MobileEntity
  {
    public Position.Horizontal lastDirection = Position.Horizontal.RIGHT;
    private Position.Horizontal _direction;

    public string direction
      => (_direction == Position.Horizontal.NONE ? lastDirection : _direction).ToString("F").ToLower();

    public Sprite1DMovement2D(
      Vector2 pos,
      float mspeed,
     Position.Horizontal direction,
      MovementState state = MovementState.IDLE
     ) : base(pos, mspeed, state)
    {
      _direction = direction;
    }

    public override string MovementInfo()
      => $"{state.ToString("F").ToLower()}";

    public override void SetDirection(Vector2 inputVector)
    {

      if (inputVector.magnitude > 0)
      {
        state = MovementState.WALK;
        _direction = Convertion.VectorToHorizontal(inputVector);
        lastDirection = _direction;
      }
      else
      {
        state = MovementState.IDLE;
      }
    }
  }
}