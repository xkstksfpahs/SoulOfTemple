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

    AudioSource ac;
    [SerializeField] AudioClip eatClip;
    SpriteRenderer itemImage;

    private void Start()
    {
        ac = GetComponent<AudioSource>();
        itemImage = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DestGameObject());
        }
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

        ac.volume = PlayerPrefs.GetFloat("Effect_Volum");
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

    IEnumerator DestGameObject()
    {
        GameManager.gm.isItem = true;
        ac.PlayOneShot(eatClip);
        itemImage.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(parent.gameObject);
    }
}
