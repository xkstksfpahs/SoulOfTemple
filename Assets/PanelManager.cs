using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager pm;
    public int stageNum;
    public int leftLife;
    int imageNum;
    [SerializeField] Text TitleText;
    [SerializeField] GameObject star;
    [SerializeField] GameObject[] image;
    [SerializeField] Text ChallText;
    // Start is called before the first frame update
    void Start()
    {
        pm = this;
        for(int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        star.GetComponent<StarComponent>().StageClick(stageNum);
        TitleText.text = "스테이지 " + stageNum.ToString();
        ChallText.text = "게임 클리어하기\n\n" + leftLife.ToString() + "목숨 이상 남겨놓고 클리어하기\n\n특정 아이템을 먹고 클리어하기";
        ImageChose();


        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < 7; i++)
            {
                string a = "Stage" + i.ToString() + "Clear";
                PlayerPrefs.SetInt(a, 0);
                string b = "Stage_" + i.ToString();
                PlayerPrefs.SetInt(b, 0);
            }
        }
    }

    void ImageChose()
    {
        if(stageNum != imageNum)
        {
            for (int i = 0; i < image.Length; i++)
            {
                image[i].SetActive(false);
            }
            imageNum = stageNum;
            image[imageNum-1].SetActive(true);
        }
    }
}
