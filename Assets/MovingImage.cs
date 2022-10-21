using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingImage : MonoBehaviour
{
    [SerializeField] Image TempleImage;

    [SerializeField] GameObject[] TempleAtoB;
    [SerializeField] GameObject[] FloorAtoB;
    [SerializeField] GameObject[] SpawnPoint;


    float TempleSpeed = 1;
    float FloorSpeed = 0.3f;

    public bool floorSpawn;
    // Start is called before the first frame update
    void Start()
    {
        TempleImage.transform.position = TempleAtoB[0].transform.position;
        floorSpawn = true;

        for( int i=0; i < SpawnPoint.Length; i++)
        {
            var floor = FloorObjectPool.GetObject();
            floor.transform.position = SpawnPoint[i].transform.position;
            floor.transform.rotation = SpawnPoint[i].transform.rotation;

            floor.transform.SetParent(GameObject.Find("Floor").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TempleImageMove();
        FloorImageMove();
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

    void FloorImageMove()
    {
        if (floorSpawn == true)
        {
            var floor = FloorObjectPool.GetObject();
            floor.transform.position = FloorAtoB[0].transform.position;
            floor.transform.rotation = FloorAtoB[0].transform.rotation;

            floor.transform.SetParent(GameObject.Find("Floor").transform);

            floorSpawn = false;
        }
    }
}
