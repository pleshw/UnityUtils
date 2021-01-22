using UnityEngine;
using UnityUtils.Angles;
using UnityUtils.Metrics;

namespace UnityUtils.Models.Entity.Movement
{
  public abstract class MovementBase
  {
    public Vector2 position;
    public float moveSpeed;

    public float moveThreshold = 0.05f;

    public Cardinal.Point direction;

    public MovementBase(Vector2 pos, float mspeed)
      => (position, moveSpeed) = (pos, mspeed);


    public abstract void SetDirection(Vector2 inputVector);

    public virtual void Move(Vector2 inputVector)
    {
      Vector2 movementMagnitude = inputVector * moveSpeed;
      Vector2 nextPosition = position + movementMagnitude * Time.fixedDeltaTime;
      position = nextPosition;
    }
  }

}