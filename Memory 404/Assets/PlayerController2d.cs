using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform GroundCheck;
    [SerializeField]
    private float runspeed=  1.5f;
    [SerializeField]
    private float jumpspeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        //KOLIZJA
        if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("ground"))) //Sprawdzanie, czy zachodzi kolizja postaci z podłożem
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //KONTROLKI
        if (Input.GetKey("d") || Input.GetKey("right")) // Poruszanie się w prawo
        {
            if (isGrounded)
                animator.Play("player_run");
            rb2d.velocity = new Vector2(runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left")) // Poruszanie się w lewo
        {
            if (isGrounded)
                animator.Play("player_run");
            rb2d.velocity = new Vector2(-runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            if (isGrounded) animator.Play("player_idle"); // Przy braku ruchu, postać odgrywa animację czekania


        }
        if (Input.GetKey("space") && isGrounded) //Skok postaci
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpspeed);
            animator.Play("player_jump");
        }
    }
}
