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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Stage(bool num)
    {
        if (CanClick == false)
        {
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
}
