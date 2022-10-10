using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject DeadBody;
    [SerializeField] GameObject playerBody;
    [SerializeField] float jump;
    jumpTrigger jt;
    public bool isGround;
    public bool oil = false;
    Rigidbody2D rb;

    GameObject elePlat;
    Vector3 platformPos;
    Vector3 distance;
    float h;

    [SerializeField] float power;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = true;
        jt = GetComponentInChildren<jumpTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gameSet || GameManager.gm.esc) return;
        Move();
        ElevatorPlatform();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //왼쪽 컨트롤을 눌러 사망
            Dead();
        }
    }

    void Move()
    {
        //ad혹은 방향키 좌우 입력으로 움직임
        h = Input.GetAxis("Horizontal"); 
        if (h > 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (h < 0) transform.localScale = new Vector3(1, 1, 1);
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);

        //스페이스바를 눌러 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGround && oil == false) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGround = false;
            jt.Jump();
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
