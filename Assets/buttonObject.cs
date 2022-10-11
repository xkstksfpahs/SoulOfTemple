﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonObject : MonoBehaviour
{
    bool isClick = false;
    SpriteRenderer sr;
    public int stageNum;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isClick)
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        if(Input.GetMouseButtonUp(0) && isClick)
        {
            isClick = false;
            sr.color = new Color(1, 1, 1, 1);

            PanelManager.pm.stageNum = stageNum;
            PanelRotation.pr.ActiveOn(stageNum);
        }
    }

    public void Click()
    {
        isClick = true;
    }
}