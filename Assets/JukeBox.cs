using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    AudioSource AudioS;
    [SerializeField] AudioClip[] AC;
    bool AudioSet;
    // Start is called before the first frame update
    void Start()
    {
        AudioSet = false;
        AudioS = GetComponent<AudioSource>();
        if(PlayerPrefs.GetFloat("First") != 1)
        {
            PlayerPrefs.SetFloat("First", 1);
            PlayerPrefs.SetFloat("Music_Volum", 1);
        }
        AudioS.clip = AC[0];
        AudioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioSet == false)
        {
            AudioS.volume = PlayerPrefs.GetFloat("Music_Volum");
        }
    }
    private void Awake()
    {
        var obj = FindObjectsOfType<JukeBox>();

        if(obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartAudio()
    {
        AudioS.Play();
    }

    public void SetMusic(int num)
    {
        StartCoroutine(MusicChange(num));
    }

    IEnumerator MusicChange(int number)
    {
        AudioSet = true;
        for(int i = 0; i < 10; i++)
        {
            AudioS.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        AudioS.Pause();
        AudioS.clip = AC[number];
        //AudioS.Play();
        Debug.Log("응애");
        AudioSet = false;
    }
}
