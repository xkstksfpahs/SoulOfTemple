using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorComponent : MonoBehaviour
{
    [SerializeField] GameObject[] A;
    [SerializeField] float spd;
    int aNum=0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = A[aNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            aNum = 1;
            move();
            //발판이 B오브젝트로 이동
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            aNum = 0;
            move();
            //발판이 A오브젝트로 이동
        }
    }


    void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, A[aNum].transform.position, spd * Time.deltaTime);
    }
}
