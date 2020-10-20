using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  public UnityEvent onPlayerHitted;
  private Rigidbody2D plyRB;
  private Animator animator;
  private bool canJump, willJump;

  public float jumpFactor, forwardFactor;
  private float forwardForce = 0f;
  // Start is called before the first frame update
  void Start()
  {
    plyRB = gameObject.GetComponent<Rigidbody2D>();
    animator = gameObject.GetComponent<Animator>();
    canJump = true;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    {
      willJump = true;
      Debug.Log("Touch Pressed");
    }
  }

  private void FixedUpdate()
  {
    if (willJump) Jump();
  }

  void Jump()
  {
    if (canJump)
    {
      canJump = false;

      if (transform.position.x < 0)
      {
        forwardForce = forwardFactor;
      }
      else
      {
        forwardForce = 0f;
      }
      plyRB.velocity = new Vector2(forwardForce, jumpFactor);
      animator.Play("player_jumping");
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Obstacle")
    {
      plyRB.constraints = RigidbodyConstraints2D.FreezeAll;
      animator.Play("player_death");
      onPlayerHitted.Invoke();
    }
    else
    {
      animator.Play("player_running");
    }
    canJump = true;
    willJump = false;
  }
}
