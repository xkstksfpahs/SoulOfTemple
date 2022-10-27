using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject DeadBody;
    [SerializeField] GameObject playerBody;
    [SerializeField] float jump;
    [SerializeField] float nomalSpeed;
    [SerializeField] Image Stamina;
    AudioSource audioS;
    [SerializeField] AudioClip[] FootStep;
    [SerializeField] AudioClip jumpSound;
    float FootStepTempo = 0;
    jumpTrigger jt;
    public bool isGround;
    public bool oil = false;
    Rigidbody2D rb;

    GameObject elePlat;
    Vector3 platformPos;
    Vector3 distance;
    float h;
    float totalSpeed, runSpeed;
    float StaminaValue;
    bool canRun;

    [SerializeField] float power;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = true;
        jt = GetComponentInChildren<jumpTrigger>();
        StaminaValue = 0.7f;
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        //anim.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gameSet || GameManager.gm.esc)
        {
            h = 0;
            return;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Translate(0, 0, 0);
        //    Debug.Log("누름");
        //}

        StaminaComponent();
        Move();
        ElevatorPlatform();

        audioS.volume = PlayerPrefs.GetFloat("Effect_Volum");

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //왼쪽 컨트롤을 눌러 사망
            Dead();
        }

        if(h != 0 && isGround == true)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void Move()
    {
        //ad혹은 방향키 좌우 입력으로 움직임
        h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            totalSpeed = h + runSpeed; //이동속도

            if (isGround == true) // 애니메이션 관련
            {
                if (runSpeed == 0)
                    FootStepTempo -= Time.unscaledDeltaTime;
                else if (runSpeed == 1)
                    FootStepTempo -= Time.unscaledDeltaTime * 2;
                if (FootStepTempo < 0)
                {
                    int i = Random.Range(0, FootStep.Length);
                    audioS.PlayOneShot(FootStep[i]);
                    FootStepTempo = 0.7f;
                }
            }
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            totalSpeed = h - runSpeed; // 이동속도

            if (isGround == true)
            {
                if (runSpeed == 0)
                    FootStepTempo -= Time.unscaledDeltaTime;
                else if (runSpeed == 1)
                    FootStepTempo -= Time.unscaledDeltaTime * 2;
                if (FootStepTempo < 0)
                {
                    int i = Random.Range(0, FootStep.Length);
                    audioS.PlayOneShot(FootStep[i]);
                    FootStepTempo = 0.7f;
                }
            }
        }
        else if(h == 0)
        {
            FootStepTempo = 0;
        }
        transform.Translate(new Vector3(totalSpeed, 0, 0) * Time.deltaTime);

        //스페이스바를 눌러 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGround && oil == false) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGround = false;
            jt.Jump();
            audioS.PlayOneShot(jumpSound);
        }
    }

    public void Dead()
    {
        //사망시 일어나는 동작
        var body = DeadObjPool.GetObject();//GameObject body = Instantiate(DeadBody);
        body.transform.position = transform.position;
        body.transform.rotation = transform.rotation;

        GameManager.gm.Respawn();
        DestroyPlayer();
        //Destroy(gameObject);
    }
    void DestroyPlayer()
    {
        PlayerObjPool.ReturnObject(this);
    }

    void ElevatorPlatform()
    {
        if(elePlat != null)
        {
            if(isGround && h == 0)
            transform.position = elePlat.transform.position - distance;
        }
    }

    void StaminaComponent()
    {
        Stamina.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.5f, 0.5f, 0));
        Stamina.fillAmount = StaminaValue;
        if (StaminaValue < 1)
        {
            StaminaValue += Time.unscaledDeltaTime / 10;
            Stamina.color = new Color(1, 1, 1, 1);
        }
        else if (StaminaValue >= 1)
        {
            StaminaValue = 1;
        }
        if (StaminaValue <= 0)
        {
            StaminaValue = 0;
            runSpeed = 0;
            canRun = false;
        }
        if (StaminaValue <= 0.25f)
        {
            Stamina.color = new Color(1, 0, 0, 1);
        }
        else
        {
            Stamina.color = new Color(1, 1, 1, 1);
            canRun = true;
        }
        if (StaminaValue == 1)
        {
            Stamina.color = new Color(1, 1, 1, 0);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && canRun == true)
        {
            runSpeed = 1;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift) && StaminaValue > 0 && canRun == true)
        {
            StaminaValue -= Time.unscaledDeltaTime / 2;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            elePlat = null;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            elePlat = collision.gameObject;
            platformPos = elePlat.transform.position;
            distance = platformPos - transform.position;
        }
    }
}
