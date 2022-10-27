using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    Rigidbody2D rb;
    float mainX,stopSpeed = 0.5f;
    float power, fallPower;
    [SerializeField] float spd;
    [SerializeField] bool isResistance;
    bool ResCom = false;
    [SerializeField] float ResMaxSpeed;
    public bool isMove = false;
    public float pillX;
    public GameObject piller;
    AudioSource ac;
    [SerializeField] AudioClip rolling;
    [SerializeField] AudioClip falling;
    bool ado = false;
    bool isjump = false, ismove = false;

    float ballSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GetComponent<AudioSource>();
        ac.clip = rolling;
        Debug.Log(GameManager.gm.ac);
    }
    private void Update()
    {
        power = rb.velocity.x;
        fallPower = rb.velocity.y;
        jump();

        if (ado == true && power >= 0.1f || power <=-0.1f)
        {
            ac.Play();
            ado = false;
        }
        else if (power <=0.1f && power >=-0.1f && ado == false)
        {
            ac.Pause();
            ado = true;
        }

        if (power > 0 && !isjump)
        {
            if (power < 1)
            {
                ballSound = power;
            }
            else if (power >= 1)
            {
                ballSound = 1;
            }
        }
        else if (power < 0 && !isjump)
        {
            if (power > -1f)
            {
                ballSound = power*-1;
            }
            else if (power <= -1f)
            {
                ballSound = 1;
            }
        }
        if (isjump) ballSound = 1;
        ac.volume = ballSound * PlayerPrefs.GetFloat("Effect_Volum");
    }
    private void FixedUpdate()
    {
        StayBall();
        if (isMove == true && piller.GetComponent<WindPiller>().canWind == true && ResCom == true)
            PushObj(pillX);
        if (isResistance == true) //만약 속도제한을 두었다면
        {
            if (power > ResMaxSpeed) // 힘이 최고속도보다 높을경우
            {
                ResCom = false;
            }
            else if (power < -ResMaxSpeed) // 힘이 최저속도보다 높을경우
            {
                ResCom = false;
            }
            else if (ResMaxSpeed > power && power > -ResMaxSpeed) // 힘이 최고속도보다 낮고, 최저속도보단 높을경우
            {
                ResCom = true;
            }
        }
        else if(isResistance == false)
        {
            ResCom = true;
        }
        //Debug.Log(rb.velocity.x);
    }
    public void PushObj(float x /*float spd*/)
    {
        mainX = transform.position.x;
        if(x - mainX < 0) //바람기둥이 몸보다 왼쪽에 있을 경우
        {
            //rb.velocity = Vector2.right * spd;
            rb.AddForce(Vector2.right * spd, ForceMode2D.Impulse);
        }
        else if(x-mainX > 0) //바람기둥이 몸보다 오른쪽에 있을 경우
        {
            //rb.velocity = Vector2.left * spd;
            rb.AddForce(Vector2.left * spd, ForceMode2D.Impulse);
        }
    }

    void StayBall()
    {
        if(rb.velocity.x > 0)
        {
            rb.AddForce(Vector2.left * stopSpeed, ForceMode2D.Impulse);
        }
        else if (rb.velocity.x < 0)
        {
            rb.AddForce(Vector2.right * stopSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (power >= 1 || power <= -1)
            {
                collision.gameObject.GetComponent<PlayerMovement>().Dead();
            }
            if(fallPower < -1f)
            {
                collision.gameObject.GetComponent<PlayerMovement>().Dead();
            }
        }
        if(ismove == true || isjump == true)
        {
            GameManager.gm.ac.PlayOneShot(falling);
            Debug.Log("부딪침");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pill"))
        {
            isMove = true;
            pillX = collision.gameObject.transform.position.x;
            piller = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pill"))
        {
            isMove = false;
            piller = null;
        }
    }

    void jump()
    {
        if (power > 0.5f || power < -0.5f)
        {
            ismove = true;
        }
        else ismove = false;

        if (fallPower < -1)
        {
            isjump = true;
        }
        else isjump = false;
    }
}
