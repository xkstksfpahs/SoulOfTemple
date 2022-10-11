using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetComponent : MonoBehaviour
{
    [SerializeField] Image[] Check;
    [SerializeField] bool[] test;
    [SerializeField] GameObject[] stars;
    [SerializeField] GameObject button;
    public int stageNumber;
    float setTime = 1f;
    float getTime;
    bool triggerStart = false, isC, isL, isI;
    int component,starCount;
    float Timer;
    string stage_Num;
    // Start is called before the first frame update
    void Start()
    {
        getTime = setTime;
        component = 0;
        starCount = 0;
        for(int i = 0; i < Check.Length; i++)
        {
            Check[i].fillAmount = 0;
        }
        for(int i=0;i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerStart)
        {
            getTime -= Time.deltaTime;
            if(getTime <= 0 && component < 3)
            {
                if (test[component])
                {
                    Timer += Time.unscaledDeltaTime;
                    Check[component].fillAmount = Mathf.Lerp(0f, 1f, Timer) * 2;
                    if (Check[component].fillAmount >= 1)
                    {
                        getTime = setTime;
                        Timer = 0;
                        component++;
                        starCount++;
                        if (component == 3)
                        {
                            triggerStart = false;
                            for(int i = 0; i < starCount; i++)
                            {
                                stars[i].SetActive(true);
                            }
                            button.SetActive(true);
                            stage_Num = "Stage_" + stageNumber.ToString();
                            if(PlayerPrefs.GetInt(stage_Num) < starCount)
                            {
                                PlayerPrefs.SetInt(stage_Num, starCount);
                            }
                        }
                    }
                }
                else
                {
                    component++;
                    if(component == 3)
                    {
                        for (int i = 0; i < starCount; i++)
                        {
                            stars[i].SetActive(true);
                        }
                        button.SetActive(true);
                        stage_Num = "Stage_" + stageNumber.ToString();
                        if (PlayerPrefs.GetInt(stage_Num) < starCount)
                        {
                            PlayerPrefs.SetInt(stage_Num, starCount);
                        }
                    }
                }
            }
        }
    }

    public void GameSet(bool isClear, bool isLife, bool isItem)
    {
        triggerStart = true;
        test[0] = isClear;
        test[1] = isLife;
        test[2] = isItem;
    }
}
