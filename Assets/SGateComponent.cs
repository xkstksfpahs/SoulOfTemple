using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGateComponent : MonoBehaviour
{
    public bool SwitchOn = false;
    [SerializeField] GameObject[] PatrolRange;
    [SerializeField] float Speed,RSpd;
    [SerializeField] float[] Nun;
    public bool mov;
    float TrueNun;
    int num = 0;
    Vector3 vec;
    Quaternion qec;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = PatrolRange[num].transform.position;
        transform.rotation = PatrolRange[num].transform.rotation;
        mov = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchOn)
        {
            num = 1;
        }
        else if (!SwitchOn)
        {
            num = 0;
        }
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, PatrolRange[num].transform.position, Speed * Time.deltaTime);

        if (mov == true)
        {
            if (SwitchOn && transform.rotation.z < Nun[num])
            {
                transform.Rotate(0, 0, Time.deltaTime * RSpd, Space.Self);
                if(transform.rotation.z >= Nun[num])
                {
                    mov = false;
                }
            }
            else if (SwitchOn && transform.rotation.z > Nun[num])
            {
                transform.Rotate(0, 0, -Time.deltaTime * RSpd, Space.Self);
                if (transform.rotation.z <= Nun[num])
                {
                    mov = false;
                }
            }

            else if (!SwitchOn && transform.rotation.z > Nun[num])
            {
                transform.Rotate(0, 0, -Time.deltaTime * RSpd, Space.Self);
                if (transform.rotation.z <= Nun[num])
                {
                    mov = false;
                }
            }
            else if (!SwitchOn && transform.rotation.z < Nun[num])
            {
                transform.Rotate(0, 0, Time.deltaTime * RSpd, Space.Self);
                if (transform.rotation.z >= Nun[num])
                {
                    mov = false;
                }
            }
        }
    }
}
