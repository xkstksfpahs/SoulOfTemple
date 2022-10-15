using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalComponent : MonoBehaviour
{
    GameSetComponent gsc;
    string stage;
    private void Start()
    {
        gsc = GameObject.Find("GameSetUI").GetComponent<GameSetComponent>();
        stage = "Stage" + gsc.stageNumber.ToString() + "Clear";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.gm.GameSet(true);
            PlayerPrefs.SetInt(stage, 1);
        }
    }
}
