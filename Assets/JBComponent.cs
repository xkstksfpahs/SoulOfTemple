using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBComponent : MonoBehaviour
{
    JukeBox jb;
    // Start is called before the first frame update
    void Start()
    {
        jb = GameObject.Find("JukeBox").GetComponent<JukeBox>();
    }

    public void SetMusic(int num)
    {
        jb.SetMusic(num);
    }
}
