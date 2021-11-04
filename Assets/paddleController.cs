using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
  public float paddleSpeed = 30.0f;
  public string Axis = "Vertical";
  private Rigidbody2D paddleBody = null;

  private void Start()
  {
    paddleBody = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    float vertInput = Input.GetAxisRaw(Axis);
    paddleBody.velocity = new Vector2(0, vertInput) * paddleSpeed;
  }
}
