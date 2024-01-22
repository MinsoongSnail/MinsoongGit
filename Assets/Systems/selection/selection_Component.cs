using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class selection_Component : MonoBehaviour
{

    //코루틴 활용가능?
    Ally ally; //선택 가능한 오브젝트 갖다놓기
    Hq hq;

    void Start()
    {
        ally = GetComponent<Ally>();
        hq = GetComponent<Hq>();

        GetComponent<Renderer>().material.color = Color.red; //공통동작 선택시 색깔 변경

        if (gameObject.CompareTag("Ally"))//아군 선택시 
        {
            ally.allySelected = true; //아군 상호작용 활성화 
        }
        
        if (gameObject.CompareTag("Hq"))//본진 선택시 
        {
             hq.hqSelected = true;
        }
    }

    void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white; //선택 해제시 공통 동작 색깔 지우기

        if (gameObject.CompareTag("Ally"))//아군 선택시 
        {
            ally.allySelected = false; //아군 선택해제시 동작
            GameManager.instance.statusUI.frontText_1.text = string.Empty;
        }
        
        if (gameObject.CompareTag("Hq"))//본진 선택시 
        {
            hq.hqSelected = false;
            GameManager.instance.statusUI.frontText_1.text = string.Empty;
        }
    }
}
