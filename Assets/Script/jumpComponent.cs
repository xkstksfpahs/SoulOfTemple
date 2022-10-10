using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpComponent : MonoBehaviour
{
    jumpTrigger jt;
    PlayerMovement pm;
    // 점프 후 플레이어가 바닥에 착지하였는지 체크하는 스크립트
    void Start()
    {
        jt = GetComponentInParent<jumpTrigger>();
        pm = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jt.isjump = false;
        pm.isGround = true;
        this.gameObject.SetActive(false);
    }
}
