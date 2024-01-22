using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem; //인풋시스템


public class Ally : MonoBehaviour
{
    //----스테이터스 적용, 표시
    public ObjectCode ObjCode; //유닛 코드 불러오기용
    public ObjectStatus ObjStatus; //유닛 코드로 스탯 불러오기

    //---- 아군의 행동과 상호작용
    Rigidbody2D rigid_Ally; //아군
    private Vector3 targetPosition; //목표 위치

    //---- 아군 선택여부
    public bool allySelected; //선택된 오브젝트 여부

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //생성자 메소드
        ObjStatus = ObjStatus.SetObjStatus(ObjectCode.Ally1); //생성자 메소드에서 SetObjStatus함수 호출
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) 를 두줄로 나눈것

        rigid_Ally = GetComponent<Rigidbody2D>();
    }
     void Start()
    {
        targetPosition = transform.position; //목표위치
    }

    void Update()
    {
        //----아군 스테이터스 설정
       switch(ObjStatus.curHp)
        {
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                AllyLevel(1);
                ObjStatus.curHp = 1; //필요?
                break;
            case 2:
                AllyLevel(2);
                ObjStatus.curHp = 2;
                break;
            case 3:
                AllyLevel(3);
                ObjStatus.curHp = 3;
                break;
        }

        //----아군 이동
        string orderText = GameManager.instance.inputCommand.inputField_Order.GetComponent<TMP_InputField>().text; //입력된 텍스트 매개변수
        if (orderText == "move" && Input.GetKeyDown(KeyCode.Return)&& allySelected)
        {
            Debug.Log("이동입력완료");
            targetPosition = GameManager.instance.inputCommand.coordinate; //묙표위치를 받아옴
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, ObjStatus.moveSpeed * Time.deltaTime); //이동함수 
        
        //----선택시 정보표시
        if (allySelected)
        {
            GameManager.instance.statusUI.frontText_1.text = ObjStatus.name;
            GameManager.instance.statusUI.backText_2.text = ObjStatus.curHp.ToString() + "/" + ObjStatus.maxHp.ToString();
            GameManager.instance.statusUI.backText_3.text = "x: " + this.transform.position.x.ToString("F2") + " y: " + this.transform.position.y.ToString("F2");
        }
    }

    void AllyLevel(int level)
    {
        switch (level) 
        {
            case 1:
                ObjStatus = ObjStatus.SetObjStatus(ObjectCode.Ally1);
                break;

            case 2:
                ObjStatus = ObjStatus.SetObjStatus(ObjectCode.Ally2);
                break;

            case 3:
                ObjStatus = ObjStatus.SetObjStatus(ObjectCode.Ally3);
                break;
        }
    }



}
