using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.gm.isItem = true;
    }
}
