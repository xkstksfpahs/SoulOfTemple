using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRotation : MonoBehaviour
{
    [SerializeField] bool isActive;
    bool activeStart = false;
    public static PanelRotation pr;
    int stage;
    string stg;
    // Start is called before the first frame update
    void Start()
    {
        pr = this;
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            activeTrue();
        }
        else if (isActive == false)
        {
            activeFalse();
        }
    }

    void activeTrue()
    {
        if (activeStart == true)
        {
            if (isActive == true) // 판넬이 보이고 있는 경우 (닫기)
            {
                transform.Rotate(new Vector3(200, 0, 0) * Time.deltaTime);
                if (transform.rotation.x >= 0.701f)
                {
                    transform.rotation = Quaternion.Euler(90, 0, 0);
                    isActive = false;
                    activeStart = false;
                }
            }
        }
    }
    void activeFalse()
    {
        if (activeStart == true)
        {
            if (isActive == false) // 판넬이 안보이는상태 인 경우 (열기)
            {
                transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
                if (transform.rotation.x <= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    isActive = true;
                    activeStart = false;
                }

            }
        }
    }

    public void ActiveTrigger()  //닫기버튼을 눌렀을 때
    {
        if (isActive == false) 
            isActive = true;

        activeStart = true;
    }
    public void ActiveOn(int num) // 스테이지를 눌렀을 때 그 스테이지의 정보 받기
    {
        if (isActive == true)
            isActive = false;
        activeStart = true;
        stage = num;
        PanelManager.pm.stageNum = num;
        stg = "Stage" + num.ToString();
    }

    public void GameStart()
    {
        LoadingSceneController.LoadScene(stg);
    }
}
