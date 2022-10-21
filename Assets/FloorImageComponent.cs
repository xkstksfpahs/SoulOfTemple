using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorImageComponent : MonoBehaviour
{
    float FloorSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * FloorSpeed);
    }
}
