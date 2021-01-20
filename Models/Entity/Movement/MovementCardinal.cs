using UnityUtils.Angles;
using UnityUtils.Metrics;
using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public class MovementCardinal : MobileEntity
  {
    public Cardinal.Points8 direction;

    public MovementCardinal(
      Vector2 pos,
      float mspeed,
      MovementState state = MovementState.IDLE,
      Cardinal.Points8 _direction = Cardinal.Points8.S
     ) : base(pos, mspeed, state)
    {
      direction = _direction;
    }

    // Retorna o estado e a direção do movimento da entidade
    // EX: "IDLE NW"
    public override string MovementInfo()
      => $"{state.ToString("F")} {direction.ToString("F")} ";

    public override void SetDirection(Vector2 inputVector)
    {

      if (inputVector.magnitude > 0)
      {
        state = MovementState.WALK;
        direction = Convertion.VectorToCardinal8(inputVector);
      }
      else
      {
        state = MovementState.IDLE;
      }
    }
  }
}