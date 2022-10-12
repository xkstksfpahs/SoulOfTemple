using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemComponent : MonoBehaviour
{
    float Speed = 1;
    [SerializeField] GameObject[] AtoB;
    [SerializeField] GameObject parent;
    int num;
    bool TupFdown = false;
    Vector2 Dest = new Vector2(0, 0);
    float Timer = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(parent.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.gm.isItem = true;
    }
    private void Update()
    {
        Shake();
        Timer -= Time.unscaledDeltaTime/2;
        if(Timer < 0)
        {
            TupFdown = !TupFdown;
            Timer = 1;
        }
    }

    void Shake()
    {
        if(TupFdown == true)
        {
            num = 0;
            transform.position = Vector2.SmoothDamp(transform.position, AtoB[num].transform.position, ref Dest, Speed);
        }
        else if(TupFdown == false)
        {
            num = 1;
            transform.position = Vector2.SmoothDamp(transform.position, AtoB[num].transform.position, ref Dest, Speed);
        }
    }
}
