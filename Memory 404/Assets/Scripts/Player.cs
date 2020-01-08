using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxspeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }

    void FixedUpdate()
    {
        float inputH = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * inputH);

        if(rb2d.velocity.x > maxspeed) //ogarniczenie prędkości w prawo
        {

            rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
        }
        if(rb2d.velocity.x < -maxspeed) //ogarniczenie prędkości w lewo
        {

            rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
        }

    }
}
