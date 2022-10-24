using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPiller : MonoBehaviour
{
    public bool canWind;
    public float windSpeed;
    [SerializeField] float ballSpeed;
    GameObject[] go;
    Animator anim;

    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canWind)
        {
            anim.SetBool("CanWind", true);
        }
        else if (!canWind)
        {
            anim.SetBool("CanWind", false);
        }
        if(canWind == true && ball != null && ball.GetComponent<BallComponent>().isMove == true)
        {
            ball.GetComponent<BallComponent>().piller = this.gameObject;
            ball.GetComponent<BallComponent>().pillX = this.transform.position.x;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.CompareTag("Ball"))
        //{
        //    if (canWind == true && collision.GetComponent<BallComponent>().isMove == true)
        //    {
        //        collision.GetComponent<BallComponent>().piller = this.gameObject;
        //        collision.GetComponent<BallComponent>().pillX = this.transform.position.x;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnG"))
        {
            canWind = false;
        }
        if (collision.CompareTag("Ball"))
        {
            ball = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SnG"))
        {
            canWind = true;
        }
        if (collision.CompareTag("Ball"))
        {
            ball = null;
        }
    }
}
