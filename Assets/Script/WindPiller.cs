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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.CompareTag("DeadPlayer") && canWind == true)
        //{
        //    collision.GetComponent<DeadPlayer>().PushObj(transform.position.x, windSpeed);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnG"))
        {
            canWind = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SnG"))
        {
            canWind = true;
        }
    }
}
