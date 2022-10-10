using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    float mainX, stopSpeed = 0.1f;
    Rigidbody2D rb;
    bool canMove,windPill,grow;
    float speed;
    float pillX;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        windPill = true;
        grow = false;
    }

    private void FixedUpdate()
    {
        if (canMove == true &&windPill == true && grow == false)
        {
            PushObj(pillX, speed);
        }
    }


    public void PushObj(float x, float spd)
    {
        if (canMove == true)
        {
            mainX = transform.position.x;
            if (x - mainX < 0)   //바람기둥이 몸보다 왼쪽에 있을 경우
            {
                transform.Translate(Vector2.right * spd);
            }
            else if (x - mainX > 0)  //바람기둥이 몸보다 오른쪽에 있을 경우
            {
                transform.Translate(Vector2.left * spd);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SnG") || collision.gameObject.CompareTag("DeadPlayer"))
        {
            canMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SnG"))
        {
            canMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grow = true;
        }
        if (collision.CompareTag("Pill"))
        {
            if (collision.GetComponent<WindPiller>().canWind == true)
            {
                windPill = true;
                pillX = collision.transform.position.x;
                speed = collision.GetComponent<WindPiller>().windSpeed;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Pill"))
        {
            if (collision.GetComponent<WindPiller>().canWind == true)
            {
                windPill = true;
                pillX = collision.transform.position.x;
                speed = collision.GetComponent<WindPiller>().windSpeed;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pill"))
        {
            windPill = false;
        }
        if (collision.CompareTag("Ground"))
        {
            grow = false;
        }
    }

    public void Push(float x, float spd)
    {
        mainX = transform.position.x;
        if (x - mainX < 0) //바람기둥이 몸보다 왼쪽에 있을 경우
        {
            //rb.velocity = Vector2.right * spd;
            rb.AddForce(Vector2.right * spd, ForceMode2D.Impulse);
        }
        else if (x - mainX > 0) //바람기둥이 몸보다 오른쪽에 있을 경우
        {
            //rb.velocity = Vector2.left * spd;
            rb.AddForce(Vector2.left * spd, ForceMode2D.Impulse);
        }
    }
}
