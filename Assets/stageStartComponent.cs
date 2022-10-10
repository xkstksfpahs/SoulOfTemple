using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageStartComponent : MonoBehaviour
{
    [SerializeField] GameObject[] stars;
    int stageNum;
    string stage;
    int starCount;
    // Start is called before the first frame update
    void Start()
    {
        stageNum = GetComponentInParent<buttonObject>().stageNum;
        for (int i = 0; i < 3; i++)
        {
            stars[i].SetActive(false);
        }
        //PlayerPrefs.SetInt("Stage_3", 0);
        Stars();
    }

    void Stars()
    {
        stage = "Stage_" + stageNum.ToString();
        starCount = PlayerPrefs.GetInt(stage);

        for(int i = 0; i < starCount; i++)
        {
            stars[i].SetActive(true);
        }
    }
}
