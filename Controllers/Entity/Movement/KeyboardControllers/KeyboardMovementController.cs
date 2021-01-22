using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Models.Entity.Movement;

namespace UnityUtils.Controllers.Entity.Movement
{
  public abstract class KeyboardMovementController : MonoBehaviour
  {
    new protected Rigidbody2D rigidbody;

    public float startMovementThreshold = 0.05f;

    public MovementBase entity;

    public readonly List<Action<MovementBase>> OnMove = new List<Action<MovementBase>>();

    private void FixedUpdate()
    {
      var playerInput = InputVector();
      if (playerInput.magnitude > 0)
      {
        entity.SetDirection(playerInput);
        if (playerInput.magnitude > startMovementThreshold)
        {
          Move();
        }
      }
    }

    protected void Move()
    {
      var input = InputVector();
      entity.Move(InputVector());
      rigidbody.MovePosition(entity.position);
      OnMove.ForEach(action => action.Invoke(entity));
    }

    // Retorna o vetor que representa a direção pressionada pelo jogador.
    // O clamp magnitude para 1 garante que os movimentos na diagonal terão a mesma velocidade dos
    // movimentos na horizontal e vertical.
    public Vector2 InputVector()
      => Vector2.ClampMagnitude(
          new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized, 1);
  }
}