using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hq : MonoBehaviour
{
    
    //----스테이터스 적용, 표시
    public ObjectCode ObjCode; //유닛 코드 불러오기용
    public ObjectStatus ObjStatus; //유닛 코드로 스탯 불러오기

    //---- 본진의 행동과 상호작용
    Rigidbody2D rigid_Hq;

    //---- 본진 선택여부
    public bool hqSelected; //선택된 오브젝트 여부

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //생성자 메소드
        ObjStatus = ObjStatus.SetObjStatus(ObjCode); //생성자 메소드에서 SetObjStatus함수 호출
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) 를 두줄로 나눈것

        rigid_Hq = GetComponent<Rigidbody2D>();
    }
     void Update()
    {
        if (hqSelected)
        {
            GameManager.instance.statusUI.frontText_1.text = ObjStatus.name;
            GameManager.instance.statusUI.backText_2.text = ObjStatus.curHp.ToString() + "/" + ObjStatus.maxHp.ToString();
            GameManager.instance.statusUI.backText_3.text = "x: " + this.transform.position.x.ToString("F2") + " y: " + this.transform.position.y.ToString("F2");
        }
    }
}
