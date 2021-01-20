
using UnityEngine;
using UnityUtils.Models.Entity.Movement;
using UnityUtils.Metrics;

namespace UnityUtils.Controllers.Entity.Movement
{
  public class KeyboardMovement1DSprite : KeyboardMovementController
  {

    private void Awake()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
      rigidbody = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      entity = new Sprite1DMovement2D(rigidbody.position, entitySpeed, Position.Horizontal.RIGHT);
    }
    private void FixedUpdate()
    {
      Move();
      var movementDirection = ((Sprite1DMovement2D)entity).direction;

      if (movementDirection == "left")
      {
        spriteRenderer.flipX = true;
      }
      else if (movementDirection == "right")
      {
        spriteRenderer.flipX = false;
      }
      animator.Play(entity.MovementInfo());
    }

  }
}