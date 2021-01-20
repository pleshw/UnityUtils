
using UnityEngine;
using UnityUtils.Models.Entity.Movement;

namespace UnityUtils.Controllers.Entity.Movement
{
  public abstract class KeyboardMovementController : MonoBehaviour
  {
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Animator animator;
    [SerializeField] new protected Rigidbody2D rigidbody;

    public MobileEntity entity;

    [SerializeField] protected float entitySpeed = 5;

    protected void Move()
    {
      var input = InputVector();
      entity.Move(InputVector());
      rigidbody.MovePosition(entity.position);
    }

    // Retorna o vetor que representa a direção pressionada pelo jogador.
    // O clamp magnitude para 1 garante que os movimentos na diagonal terão a mesma velocidade dos
    // movimentos na horizontal e vertical.
    Vector2 InputVector()
      => Vector2.ClampMagnitude(
          new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized, 1);
  }
}