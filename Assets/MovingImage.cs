using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingImage : MonoBehaviour
{
    [SerializeField] Image TempleImage;

    [SerializeField] GameObject[] TempleAtoB;


    float TempleSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        TempleImage.transform.position = TempleAtoB[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TempleImageMove();
    }

    void TempleImageMove()
    {
        if (TempleImage.transform.position.x > TempleAtoB[1].transform.position.x)
        {
            TempleImage.transform.Translate(Vector2.left * TempleSpeed);
        }

        if(TempleImage.transform.position.x <= TempleAtoB[1].transform.position.x)
        {
            TempleImage.transform.position = TempleAtoB[0].transform.position;
        }
    }
}
