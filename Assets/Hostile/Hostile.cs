using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hostile: MonoBehaviour
{
    //----스테이터스 적용, 표시
    public ObjectCode ObjCode; //유닛 코드 불러오기용
    public ObjectStatus ObjStatus; //유닛 코드로 스탯 불러오기

    //---- 적군의 행동과 상호작용
    public Rigidbody2D target; //적의 목표 
    Rigidbody2D rigidHostile;
    SpriteRenderer spriterHostile;

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //생성자 메소드
        ObjStatus = ObjStatus.SetObjStatus(ObjCode); //생성자 메소드에서 SetObjStatus함수 호출
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) 를 두줄로 나눈것

        rigidHostile = GetComponent<Rigidbody2D>();
        spriterHostile = GetComponent<SpriteRenderer>();
    }
    void OnEnable() //활성화 되었을 떄
    {
        target = GameManager.instance.Hq.GetComponent<Rigidbody2D>(); //생성(활성화) 되었을때 타겟 설정                                                                 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjStatus.curHp == 0)
        {
            return;
        }

        Vector2 dirVec = target.position - rigidHostile.position; // 목표위치 - 적위치= 목표와 나의 거리+방향  
        Vector2 nextVec = dirVec.normalized * ObjStatus.moveSpeed * Time.fixedDeltaTime; // 방향으로 이동
        rigidHostile.MovePosition(rigidHostile.position + nextVec);
        rigidHostile.velocity = Vector2.zero; //물리영향 제거

    }

    void LateUpdate() //모든 update함수 호출 이후 마지막으로 호출됨
    {
        if (ObjStatus.curHp == 0)
        {
            return;
        }
    }


}


