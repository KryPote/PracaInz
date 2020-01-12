using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxspeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    public bool grounded;
    public bool candoubleJump;

    public int curHealth = 3;
    public int maxHealth = 3;

    private Rigidbody2D rb2d;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;


    }

    void Update()
    {
        anim.SetBool("candoubleJump", candoubleJump);
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //Kontrolki lewo-prawo
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        //Skok i doublejump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded) //Zwykły skok
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                candoubleJump = true;
            }
            else
            {
                if (candoubleJump) //Doublejump
                {
                    candoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(((Vector2.up * jumpPower)/2) + ((Vector2.up * jumpPower)/4));
                }

            }
            
        }
        //Zdrufko
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Death();
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float inputH = Input.GetAxis("Horizontal");

        //Sztuczne tarcie aka wygaszanie prędkości gracza
        if (grounded)
        {
            rb2d.velocity = easeVelocity;

        }


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
    void Death()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
