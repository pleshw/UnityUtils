
using UnityEngine;
using UnityUtils.Models.Entity.Movement;
using UnityUtils.Metrics;

namespace UnityUtils.Controllers.Entity.Movement
{
  public class KeyboardMovement1D : KeyboardMovementController
  {
    public float entitySpeed = 5.0f;

    private void Awake()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      entity = new Movement1D(rigidbody.position, entitySpeed, Cardinal.Point.E);
    }
  }
}