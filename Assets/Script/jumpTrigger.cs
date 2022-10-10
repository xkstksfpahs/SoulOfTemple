using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{
    [SerializeField] GameObject bc;
    public bool isjump = false;
    // 점프를 했을 때 점프타일(게임오브젝트 bc)을 켜주는 스크립트
    void Start()
    {
        bc.SetActive(false);
    }

    public void Jump()
    {
        Invoke("invokeJump", 0.3f);
    }

    void invokeJump()
    {
        bc.SetActive(true);
    }
}
