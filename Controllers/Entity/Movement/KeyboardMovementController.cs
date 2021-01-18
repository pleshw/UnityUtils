
using UnityEngine;
using UnityUtils.Models.Entity.Movement;

namespace UnityUtils.Controllers.Entity.Movement
{
  public class KeyboardMovementController : MonoBehaviour
  {
    [SerializeField] private Animator animator;
    [SerializeField] new private Rigidbody2D rigidbody;

    MobileEntity entity;

    [SerializeField] private float entitySpeed = 1;

    void Awake()
    {
      animator = GetComponent<Animator>();
      rigidbody = GetComponent<Rigidbody2D>();
      entity = new MobileEntity(rigidbody.position, entitySpeed);
    }

    void FixedUpdate()
    {
      Move();
    }

    void Move()
    {
      var input = InputVector();
      Debug.Log($"{entity.MovementInfo()} {input.x} {input.y}");
      entity.Move(InputVector());
      rigidbody.MovePosition(entity.position);
      // animator.Play(entity.MovementInfo());
    }

    // Retorna o vetor que representa a direção pressionada pelo jogador.
    // O clamp magnitude para 1 garante que os movimentos na diagonal terão a mesma velocidade dos
    // movimentos na horizontal e vertical.
    Vector2 InputVector()
      => Vector2.ClampMagnitude(
          new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized, 1);
  }
}