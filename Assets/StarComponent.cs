using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarComponent : MonoBehaviour
{
    [SerializeField] GameObject[] stars;
    int starCount;
    string stage;
    [SerializeField] int cc;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            stars[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageClick(int num)
    {
        for (int i = 0; i < 3; i++)
        {
            stars[i].SetActive(false);
        }

        stage = "Stage_" + num.ToString();
        starCount = PlayerPrefs.GetInt(stage);

        for (int i = 0; i < starCount; i++)
        {
            stars[i].SetActive(true);
        }
        //Debug.Log(stage);
        //Debug.Log(starCount);
    }
}
