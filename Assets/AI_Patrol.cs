using UnityEngine;
using System.Collections;



public class AI_Patrol : MonoBehaviour
{
	public bool mustPatrol;
	public Rigidbody2D rb;
	public float walkSpeed = 1;
	private bool mustFlip;

	public Transform groundCheckPos;
	public LayerMask groundLayer;

	public Collider2D BodyCollider;

	void Start()
	{
		mustPatrol = true;
	}

	void Update()
	{
		if (mustPatrol)
		{
			Patrol();
		}
	}

	private void FixedUpdate()
	{
		//if patrolling, check to see if the groundcheck object is no longer overlapping the ground
		if (mustPatrol || BodyCollider.IsTouchingLayers(groundLayer))
		{
			mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
		}
	}

	void Patrol()
	{
		//flip if the groundcheck object is no longer overlapping the ground
		if (mustFlip)
		{
			Flip();
		}

		//add a moving direction multiplying walkspeed by time
		rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
	}

	void Flip()
	{
		mustPatrol = false;
		//perform the flipping action
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		walkSpeed *= -1;
		mustPatrol = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//check to see if the player has hit the hazard
		if (other.name == "Player")
		{
			FindObjectOfType<LevelManager>().EndGame();
		}
	}
}
