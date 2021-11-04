using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
  public GameObject LeftPaddle;
  public GameObject RightPaddle;

  public Text LeftScore;
  public Text RightScore;

  private float speed = 20.0f;

  private Rigidbody2D ballBody = null;

  private System.Random rnd;

  private int leftScore = 0;
  private int rightScore = 0;

  // Start is called before the first frame update
  void Start()
  {
    ballBody = GetComponent<Rigidbody2D>();
    rnd = new System.Random();

    StartNewRound(rnd.Next(1) == 1);
  }

  private void StartNewRound(bool goRight)
  {
    LeftPaddle.transform.position = new Vector3(LeftPaddle.transform.position.x, 0);
    RightPaddle.transform.position = new Vector3(RightPaddle.transform.position.x, 0);

    transform.position = Vector2.zero;

    float y = Random.Range(-1.0f, 1.0f);

    if (goRight)
    {
      ballBody.velocity = new Vector2(1, y).normalized * speed;
    } else
    {
      ballBody.velocity = new Vector2(-1, y).normalized * speed;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.name == "LeftRight")
    {
      float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
      Vector2 direction = new Vector2(1, y).normalized;
      ballBody.velocity = direction * speed;
    } else if (collision.gameObject.name == "RacketRight")
    {
      float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
      Vector2 direction = new Vector2(-1, y).normalized;
      ballBody.velocity = direction * speed;
    } else if (collision.gameObject.name == "LeftWall")
    {
      rightScore += 1;
      RightScore.text = rightScore.ToString();
      StartNewRound(false);
    }
    else if (collision.gameObject.name == "RightWall")
    {
      leftScore += 1;
      LeftScore.text = leftScore.ToString();
      StartNewRound(true);
    }

  }
}
