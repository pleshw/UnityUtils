using UnityEngine;
using UnityUtils.Angles;
using UnityUtils.Models.Entity.Movement;

namespace UnityUtils.Controllers.Entity.Movement
{
  public class Sprite1DController : MonoBehaviour
  {
    private SpriteRenderer spriteRenderer;

    private KeyboardMovementController movementController;

    public bool spriteFaceRight = true;

    private void Awake()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
      movementController = GetComponent<KeyboardMovementController>();

      movementController.OnMove.Add(entity =>
      {
        var directionRaw = ((Movement1D)entity).direction;
        var direction = Convertion.CardinalToPosition(directionRaw);

        if (direction == "left")
        {
          spriteRenderer.flipX = spriteFaceRight;
        }
        else if (direction == "right")
        {
          spriteRenderer.flipX = !spriteFaceRight;
        }
      });
    }
  }
}