using UnityEngine;


namespace UnityUtils.Models.Entity.Movement
{
  public abstract class MobileEntity
  {
    public Vector2 position;
    public float moveSpeed;

    public MovementState state;

    public MobileEntity(
      Vector2 pos,
      float mspeed,
      MovementState _state = MovementState.IDLE
     )
      => (position, moveSpeed, state) = (pos, mspeed, _state);

    // Retorna o estado e a direção do movimento da entidade
    // EX: "IDLE NW"
    public abstract string MovementInfo();

    public abstract void SetDirection(Vector2 inputVector);

    public virtual void Move(Vector2 inputVector)
    {
      Vector2 movementMagnitude = inputVector * moveSpeed;
      Vector2 nextPosition = position + movementMagnitude * Time.fixedDeltaTime;
      position = nextPosition;
      SetDirection(inputVector);
    }
  }

}