using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonObject : MonoBehaviour
{
    bool isClick = false;
    SpriteRenderer sr;
    public int stageNum;
    StageGameManager sgm;
    [SerializeField] GameObject UnlockedSprite;
    bool isLocked;
    string beforeStage;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage0Clear", 1);
        sr = GetComponent<SpriteRenderer>();
        sgm = GameObject.Find("StageGameManager").GetComponent<StageGameManager>();
        beforeStage = "Stage" + (stageNum - 1).ToString() + "Clear";
        if(PlayerPrefs.GetInt(beforeStage) == 1) // 이전 스테이지를 클리어 했을 때
        {
            isLocked = false;
            UnlockedSprite.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(beforeStage) == 0)// 이전 스테이지를 클리어 하지 않았을 때
        {
            isLocked = true;
            UnlockedSprite.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked == true) return;
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
        if (sgm.isStage == false && sgm.Cut.color.a < 0.1f)
        {
            isClick = true;
        }
    }
}
