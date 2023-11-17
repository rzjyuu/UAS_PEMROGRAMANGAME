using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public float direction = 0f;
    private Rigidbody2D Player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            Player.velocity = new Vector2(direction * speed, Player.velocity.y);
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
        else if (direction < 0f)
        {
            Player.velocity = new Vector2(direction * speed, Player.velocity.y);
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
        else
        {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            Player.velocity = new Vector2(Player.velocity.x, jumpSpeed);
        }
        playerAnimation.SetFloat("speed", Mathf.Abs(Player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }
}