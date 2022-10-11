using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    AudioSource AudioS;
    [SerializeField] AudioClip[] AC;
    // Start is called before the first frame update
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioS.volume = PlayerPrefs.GetFloat("Music_Volum");
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusic(int num)
    {

    }
}
