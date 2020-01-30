using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator anim;
    public bool candoubleJump;

    public int curHealth;
    public bool damaged;
    public GameMaster gameMaster;

    public bool grounded;
    public float jumpPower = 150f;
    public int maxHealth = 3;
    public float maxspeed = 3;

    private Rigidbody2D rb2d;
    public float speed = 50f;


    // Start is called before the first frame update
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
       
        curHealth = maxHealth;
    }


    private void Update()
    {
        anim.SetBool("candoubleJump", candoubleJump);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("damaged", damaged);

        //Kontrolki lewo-prawo
        if (Input.GetAxis("Horizontal") < -0.1f)
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
                    rb2d.AddForce((Vector2.up * jumpPower / 2 )+ (Vector2.up * jumpPower / 4));
                }
            }
        }

        //Zdrowie
        if (curHealth > maxHealth) curHealth = maxHealth;
        if (curHealth <= 0) Death();
    }

    private void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        var inputH = Input.GetAxis("Horizontal");

        //Sztuczne tarcie aka wygaszanie prędkości gracza
        if (grounded) rb2d.velocity = easeVelocity;
        rb2d.AddForce(Vector2.right * speed * inputH);

        if (rb2d.velocity.x > maxspeed) //ogarniczenie prędkości w prawo
            rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxspeed) //ogarniczenie prędkości w lewo
            rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);   //<----------------------
            rb2d.AddForce(new Vector3(knockBackDir.x * -100, knockBackDir.y * knockBackPwr, transform.position.z));
        }
        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            gameMaster.nuts += 1;
        }
    }
}