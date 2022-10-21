using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAComponent : MonoBehaviour
{
    MovingImage MI;
    // Start is called before the first frame update
    void Start()
    {
        MI = GetComponentInParent<MovingImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            MI.floorSpawn = true;
        }
    }
}
