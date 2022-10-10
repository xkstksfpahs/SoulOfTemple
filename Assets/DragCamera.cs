using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragCamera : MonoBehaviour
{
    Vector2 clickPoint;
    float dragSpeed = 30;
    [SerializeField] Slider CamSlider;
    Camera cam;
    Vector3 mousePos;
    int range;
    bool isSlider = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라의 포지션은 슬라이더의 밸류값에 의해 정해짐 좌우로만 이동하도록 하기 위함
        transform.position = new Vector3 (CamSlider.value * 10, 0, -10);

        if (Input.GetMouseButtonDown(0)) // 마우스 클릭시 버튼 오브젝트에 닿았을경우
        {
            mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward);
            Debug.DrawRay(mousePos, transform.forward * 10f, Color.red, 0.3f);
            if (hit)
            {
                //isSlider = false;
                if (hit.transform.CompareTag("ButtonObj"))
                {
                    hit.transform.GetComponent<buttonObject>().Click();
                }
            }
            
        }
        screenSlider();
    }


    void screenSlider()
    {
        // 게임화면에서 화면을 움직일 경우 슬라이더의 밸류값 변경 = DragCamera에서 카메라의 포지션위치를 정하는 값을 구함
        if (Input.GetMouseButton(0) && isSlider == false)
        {
            if (Input.GetMouseButtonDown(0))
                clickPoint = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
            Vector3 move = pos * (Time.deltaTime * dragSpeed) * 2;
            if (pos.x > 0 || pos.x < 0)
                range = 1;
            else range = 0;

            if (range == 1)
            {
                CamSlider.value -= move.x;
                clickPoint = Input.mousePosition;
            }
        }
    }
}
