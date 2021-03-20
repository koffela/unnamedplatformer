using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    //Start of my first game!
    Rigidbody2D rb;
    private float speed = 8f;
    private float jumpForce = 10f;

    //public Transform isGroundedChecker;
    //public float checkGroundRadius;

    //unlock access to the groundLayer layermask in this script
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Start()
	{
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        CheckIfGrounded();
        BetterJump();
        Flip();
    }


    void Run()
    {
        //this allows the player to move
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f);
    }


    void Jump()
	{
        //player's default jump action
        if (Input.GetKeyDown(KeyCode.Space) && CheckIfGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    void BetterJump()
    {
        //builds a 'mario' type jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    bool CheckIfGrounded()
    {
        //check to see if the player is on the ground by shooting a raycast downwards
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.8f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }


    void Flip()
	{
        //flip the player sprite since they are moving in the opposite direction now
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }

    void OnCollisionEnter (Collision collisionInfo)
	{
        if (collisionInfo.collider.tag == "hazard")
        {
            FindObjectOfType<LevelManager>().EndGame();
        }
        else if (collisionInfo.collider.tag == "enemy")
        {
            //nothing yet
        }
    }
}
