using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX = 0f;
    private CapsuleCollider2D collision;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum Movement { Idle, Running, Jump, Fall };
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private int jumps = 1;
    [SerializeField] private int jumpCounter = 1;
    public LayerMask jumpGround;
    public Transform GroundTransform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        collision = rb.GetComponent<CapsuleCollider2D>();
        anim = rb.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * MoveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCounter < jumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            AudioManager.instance.PlayPlayerSfx("Player_Jump");
            jumpCounter++;
        }
        if (Grounded()) jumpCounter = 0;

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        Movement state;
        if (dirX > 0f)
        {
            state = Movement.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = Movement.Running;
            sprite.flipX = true;
        }
        else
        {
            state = Movement.Idle;
        }
        if(rb.velocity.y > .1f && !Grounded())
        {

            state = Movement.Jump;

        }
        if (rb.velocity.y < -.1f)
        {
            state = Movement.Fall;
        }
        anim.SetInteger("Movement", (int)state);
    }
    private bool Grounded()
    {
        return Physics2D.BoxCast(GroundTransform.position,new Vector2(0.6f, 0.1f), 0, Vector2.down, 0, jumpGround);
    }
}
