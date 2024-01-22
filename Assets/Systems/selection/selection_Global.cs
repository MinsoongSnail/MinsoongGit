using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class selection_Global : MonoBehaviour
{
    selected_List selected_Table; //selected_Dictionary 스크립트 지역변수

    //레이캐스트
    RaycastHit2D hit;

    //레이캐스트 3d를 2d로 바꿔야함??
    Vector3 mousePos1; //마우스 다운시 마우스 위치

    void Start()
    {
        selected_Table = GetComponent<selected_List>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 버튼이 눌렸을떄 (not released)
        {
            Vector3 mousePos3 = Camera.main.WorldToScreenPoint(Input.mousePosition); //ScreenToWorldPoint의 z좌표는 비면 카메라위치로 강제이동??
            mousePos1 = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition).x,(Input.mousePosition).y, mousePos3.z)); //첫 클릭 좌표
        }

        if (Input.GetMouseButtonUp(0)) //마우스 버튼이 떨어졌을떄
        {
            if (EventSystem.current.IsPointerOverGameObject()) //UI 클릭시 레이캐스트 안함
            {
                return;
            }
            hit = Physics2D.Raycast(mousePos1, Vector2.zero, 0f);

                if (hit) //레이캐스트로 대상 탐색
                {
                    Debug.Log("마우스로 대상 선택됨");
                    selected_Table.DeselectAll(); //기존에 있던건 지우고
                    selected_Table.AddSelected(hit.transform.gameObject);//오브젝트좌표를 테이블에 추가
                }
                else //레이캐스트로 대상을 탐색했는데 오브젝트가 없다면
                {
                    selected_Table.DeselectAll();
                }
        }

    }
}
