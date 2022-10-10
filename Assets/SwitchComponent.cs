using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchComponent : MonoBehaviour
{
    [SerializeField] GameObject sgateComponent;
    [SerializeField] bool isOneShotSwitch;
    SGateComponent SGC;
    // Start is called before the first frame update
    void Start()
    {
        SGC = sgateComponent.GetComponent<SGateComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DeadPlayer") || collision.CompareTag("Ball"))
        {
            SGC.SwitchOn = true;
            SGC.mov = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isOneShotSwitch)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("DeadPlayer") || collision.CompareTag("Ball"))
            {
                SGC.SwitchOn = false;
                SGC.mov = true;
            }
        }
    }
}
