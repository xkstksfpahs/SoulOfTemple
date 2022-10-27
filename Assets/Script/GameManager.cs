using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int life;
    public int leftLife;
    [SerializeField] GameObject playerBody;
    [SerializeField] GameObject gameSetUI;
    [SerializeField] GameObject escUI;
    [SerializeField] Text lifeText;
    public AudioSource ac;
    GameObject spawnPoint;
    public bool gameSet = false;
    bool setUI = false;

    bool isClear = false, isLife = false;
    public bool isItem = false;
    public bool esc = false;
    bool escSet = false;
    string ReRound;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        gameSetUI.transform.rotation = Quaternion.Euler(90, 0, 0);
        escUI.transform.rotation = Quaternion.Euler(90, 0, 0);
        ReRound = "Stage" + gameSetUI.GetComponent<GameSetComponent>().stageNumber.ToString();
        lifeText.text = "X" + life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ac.volume = PlayerPrefs.GetFloat("Effect_Volum");
        if (gameSet && setUI)
        {
            gameSetUI.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
            if(gameSetUI.transform.rotation.x <= 0)
            {
                gameSetUI.transform.rotation = Quaternion.Euler(0, 0, 0);
                setUI = false;
                gameSetUI.GetComponent<GameSetComponent>().GameSet(isClear, isLife, isItem);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc == true)
                esc = false;
            else if (esc == false)
                esc = true;
            escSet = true;
        }
        if (escSet)
        {
            ESCUI();
        }
    }

    void ESCUI()
    {
        if(esc == true) //esc메뉴를 켰을 때
        {
            escUI.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
            if(escUI.transform.rotation.x <= 0)
            {
                escUI.transform.rotation = Quaternion.Euler(0, 0, 0);
                escSet = false;
            }
        }
        else if(esc == false) //esc메뉴를 껐을 때
        {
            escUI.transform.Rotate(new Vector3(200, 0, 0) * Time.deltaTime);
            if(escUI.transform.rotation.x >= 0.701f)
            {
                escUI.transform.rotation = Quaternion.Euler(90, 0, 0);
                escSet = false;
            }
        }
    }

    public void Respawn()
    {
        if(life > 0)
        {
            life--;
            var go = PlayerObjPool.GetObject();//Instantiate(playerBody);
            go.transform.position = spawnPoint.transform.position;
            go.transform.rotation = spawnPoint.transform.rotation;
            lifeText.text = "X" + life.ToString();
        }
    }

    public void GameSet(bool isC)
    {
        gameSet = true;
        setUI = true;
        isClear = isC;

        if(isC == true)
        {
            if(life >= leftLife)
            {
                isLife = true;
            }
        }
    }
    public void ExitStage()
    {
        LoadingSceneController.LoadScene("Stage");
    }

    public void Point()
    {

    }

    public void Continue()
    {
        esc = false;
        escSet = true;
    }
    public void ReStartGame()
    {
        LoadingSceneController.LoadScene(ReRound);
    }
}
