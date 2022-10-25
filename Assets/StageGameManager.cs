using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageGameManager : MonoBehaviour
{
    [SerializeField] GameObject TitleUI;
    public Image Cut;
    public bool isStage;
    float Acolor = 0;
    bool CanClick = false;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("isStage", 1);
        if (PlayerPrefs.GetInt("isStage") == 1) isStage = true;
        else if (PlayerPrefs.GetInt("isStage") == 0) isStage = false;
        TitleUI.SetActive(isStage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Stage(bool num)
    {
        if (CanClick == false)
        {
            if(num == true)
            {
                PlayerPrefs.SetInt("isStage", 1);
                Debug.Log("이건가?");
            }
            else if(num == false)
            {
                PlayerPrefs.SetInt("isStage", 0);
            }
            isStage = num;
            CanClick = true;
            StartCoroutine(UIChange());
        }
    }
    public void Option()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
        PlayerPrefs.SetInt("isStage", 1);
    }

    IEnumerator UIChange()
    {
        for(int i = 0; i < 100; i++)
        {
            Acolor += 0.01f;
            Cut.color = new Color(0, 0, 0, Acolor);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        TitleUI.SetActive(isStage);
        for (int i = 0; i < 100; i++)
        {
            Acolor -= 0.01f;
            Cut.color = new Color(0, 0, 0, Acolor);
            yield return new WaitForSeconds(0.01f);
        }
        Cut.color = new Color(0, 0, 0, 0);
        CanClick = false;
    }
    //IEnumerator GameStartUIChange()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Acolor += 0.01f;
    //        Cut.color = new Color(0, 0, 0, Acolor);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    yield return new WaitForSeconds(0.5f);
    //}
}
