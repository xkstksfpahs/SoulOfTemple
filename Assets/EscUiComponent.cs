using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscUiComponent : MonoBehaviour
{
    [SerializeField] GameObject options;
    bool op = true;
    bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            if (op == true) //옵션창 켜져있을 때
            {
                options.SetActive(false);
                trigger = false;
            }
            else if (op == false) //옵션창 꺼져있을 때
            {
                options.SetActive(true);
                trigger = false;
            }
        }
    }

    public void OptionCom()
    {
        trigger = true;

        if (op == true)
            op = false;
        else if (op == false)
            op = true;
    }
}
