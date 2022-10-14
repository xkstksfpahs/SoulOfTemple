using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGameManager : MonoBehaviour
{
    [SerializeField] GameObject optionObj;
    [SerializeField] Slider MusicSlider;
    bool isOption;
    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("Music_Volum");
        isOption = false;
        optionObj.SetActive(false);
    }
    private void Update()
    {
        Option();
    }
    void Option()
    {
        if (isOption == true)
        {
            PlayerPrefs.SetFloat("Music_Volum", MusicSlider.value);
        }
        else if (isOption == false)
        {
            MusicSlider.value = PlayerPrefs.GetFloat("Music_Volum");
        }
    }



    public void OptionButton(bool num)
    {
        isOption = num;
        optionObj.SetActive(num);
    }
}
