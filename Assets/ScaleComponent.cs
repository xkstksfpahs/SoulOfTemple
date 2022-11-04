using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleComponent : MonoBehaviour
{
    [SerializeField] GameObject[] ScreenButtons;
    [SerializeField] GameObject[] SizeButtons;
    bool ScreenMod;
    string buttonT;
    int Width, Vertical;
    [SerializeField] Text buttonText;
    [SerializeField] Text SizeText;
    [SerializeField] GameObject ScreenIm;
    [SerializeField] GameObject SizeIm;
    [SerializeField] Image SB;
    [SerializeField] Image sizeB;
    // Start is called before the first frame update
    void Start()
    {
        ScreenIm.SetActive(false);
        for (int i = 0; i < ScreenButtons.Length; i++)
        {
            ScreenButtons[i].SetActive(false);
        }
        for (int i = 0; i < SizeButtons.Length; i++)
        {
            SizeButtons[i].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Width") == 0)
        {
            PlayerPrefs.SetInt("Width", 1920);
            PlayerPrefs.SetInt("Vertical", 1080);
        }
        if (PlayerPrefs.GetString("ScreenV") == "전체화면" /*&& PlayerPrefs.GetString("ScreenV") != "창모드"*/)
        {
            //PlayerPrefs.SetString("ScreenV", "전체화면");
            buttonT = PlayerPrefs.GetString("ScreenV");
            buttonText.text = buttonT;
            ScreenMod = true;
        }
        else if (PlayerPrefs.GetString("ScreenV") == "창모드")
        {
            buttonT = PlayerPrefs.GetString("ScreenV");
            buttonText.text = buttonT;
            ScreenMod = false;
        }
        Width = PlayerPrefs.GetInt("Width");
        Vertical = PlayerPrefs.GetInt("Vertical");
        SizeText.text = Width.ToString() + "x" + Vertical.ToString();
        SB.color = new Color(1, 1, 1, 0.85f);
        sizeB.color = new Color(1, 1, 1, 0.85f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void screen()
    {
        //화면상태조절 버튼을 눌렀을 때 버튼이 나타나게 함
        for (int i = 0; i < ScreenButtons.Length; i++)
        {
            ScreenButtons[i].SetActive(true);
        }
        ScreenIm.SetActive(true);
        SB.color = new Color(1, 1, 1, 0.7f);
    }
    void CloseScreen()
    {
        //ChoseScreen()에서 원하는 창을 고른 후 버튼이 사라지게 함
        for (int i = 0; i < ScreenButtons.Length; i++)
        {
            ScreenButtons[i].SetActive(false);
        }
        ScreenIm.SetActive(false);
        SB.color = new Color(1, 1, 1, 0.85f);
    }

    public void Size()
    {
        //해상도크기 조절 버튼을 눌렀을 때 버튼이 나타나게 함
        for (int i = 0; i < SizeButtons.Length; i++)
        {
            SizeButtons[i].SetActive(true);
        }
        SizeIm.SetActive(true);
        sizeB.color = new Color(1, 1, 1, 0.7f);
    }
    void CloseSize()
    {
        //ChoseResolution()에서 원하는 사이즈를 고른 후 버튼이 사라지게 함
        for (int i = 0; i < SizeButtons.Length; i++)
        {
            SizeButtons[i].SetActive(false);
        }
        SizeIm.SetActive(false);
        sizeB.color = new Color(1, 1, 1, 0.85f);
    }

    public void ChoseScreen(bool mod)
    {
        //입력받은 mod가 true이면 전체화면, false이면 창모드
        ScreenMod = mod;
        Screen.SetResolution(Width, Vertical, ScreenMod);
        if (ScreenMod == true)
            buttonT = "전체화면";
        else if (ScreenMod == false)
            buttonT = "창모드";
        buttonText.text = buttonT;
        CloseScreen();
    }
    public void ChoseRes(int width)
    {
        //입력받은 int값을 해상도 세로 크기에 저장 후 아래 ChoseResolution()함수로 넘어감
        PlayerPrefs.SetInt("Width", width);

        Width = PlayerPrefs.GetInt("Width");
    }
    public void ChoseResolution(int vertical)
    {
        //입력받은 int값을 해상도 가로 크기에 저장 후 위 ChoseRes()에서 저장한 세로값을 가져와 해상도 크기 조절
        PlayerPrefs.SetInt("Vertical", vertical);

        Vertical = PlayerPrefs.GetInt("Vertical");

        Screen.SetResolution(Width, Vertical, ScreenMod);
        CloseSize();
        SizeText.text = Width.ToString() + "x" + Vertical.ToString();
    }
}
