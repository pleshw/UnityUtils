using UnityEngine;
using UnityUtils.Angles;
using UnityUtils.Metrics;

namespace UnityUtils.Models.Entity.Movement
{
  public class MobileEntity
  {
    public Vector2 position;
    public float moveSpeed;

    public MovementState state;
    public Cardinal.Point direction;

    public MobileEntity(
      Vector2 pos,
      float mspeed,
      MovementState _state = MovementState.IDLE,
      Cardinal.Point _direction = Cardinal.Point.S)
      => (position, moveSpeed, state, direction) = (pos, mspeed, _state, _direction);

    // Retorna o estado e a direção do movimento da entidade
    // EX: "IDLE NW"
    public string MovementInfo() => MovementInfo(this);
    public static string MovementInfo(MobileEntity m)
      => $"{m.state.ToString("F")} {m.direction.ToString("F")} ";

    public void SetDirection(Vector2 inputVector)
    {

      if (inputVector.magnitude > 0)
      {
        state = MovementState.WALK;
        direction = Convertion.VectorToCardinal(inputVector);
      }
      else
      {
        state = MovementState.IDLE;
      }
    }

    public void Move(Vector2 inputVector)
    {
      Vector2 movementMagnitude = inputVector * moveSpeed;
      Vector2 nextPosition = position + movementMagnitude * Time.fixedDeltaTime;
      position = nextPosition;
      SetDirection(inputVector);
    }
  }

}