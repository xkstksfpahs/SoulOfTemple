using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderComponent : MonoBehaviour
{
    Vector2 clickPoint;
    float dragSpeed = 30;
    Slider slider;
    int range;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임화면에서 화면을 움직일 경우 슬라이더의 밸류값 변경 = DragCamera에서 카메라의 포지션위치를 정하는 값을 구함
        //if (Input.GetMouseButton(0)) 
        //{
        //    if (Input.GetMouseButtonDown(0))
        //        clickPoint = Input.mousePosition;
        //    Vector3 pos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
        //    Vector3 move = pos * (Time.deltaTime * dragSpeed) * 0.1f;
        //    if (pos.x > 0 || pos.x < 0)
        //        range = 1;
        //    else range = 0;

        //    if (range == 1)
        //        slider.value -= move.x;
        //}
    }
}
