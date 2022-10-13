using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    Animator anim;
    bool isTrigger = false;
    int leftLife;
    [SerializeField] Text challengeLife;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isTrigger == false)
        {
            leftLife = GameManager.gm.leftLife;
            challengeLife.text = "목숨을 " + leftLife.ToString() + "개 이상 남겨놓기";
            anim.SetTrigger("Start");
            isTrigger = true;
        }
    }

    public void AnimExitTrigger()
    {
        isTrigger = false;
    }
}
