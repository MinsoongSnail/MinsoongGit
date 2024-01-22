using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hostile: MonoBehaviour
{
    //----�������ͽ� ����, ǥ��
    public ObjectCode ObjCode; //���� �ڵ� �ҷ������
    public ObjectStatus ObjStatus; //���� �ڵ�� ���� �ҷ�����

    //---- ������ �ൿ�� ��ȣ�ۿ�
    public Rigidbody2D target; //���� ��ǥ 
    Rigidbody2D rigidHostile;
    SpriteRenderer spriterHostile;

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //������ �޼ҵ�
        ObjStatus = ObjStatus.SetObjStatus(ObjCode); //������ �޼ҵ忡�� SetObjStatus�Լ� ȣ��
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) �� ���ٷ� ������

        rigidHostile = GetComponent<Rigidbody2D>();
        spriterHostile = GetComponent<SpriteRenderer>();
    }
    void OnEnable() //Ȱ��ȭ �Ǿ��� ��
    {
        target = GameManager.instance.Hq.GetComponent<Rigidbody2D>(); //����(Ȱ��ȭ) �Ǿ����� Ÿ�� ����                                                                 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjStatus.curHp == 0)
        {
            return;
        }

        Vector2 dirVec = target.position - rigidHostile.position; // ��ǥ��ġ - ����ġ= ��ǥ�� ���� �Ÿ�+����  
        Vector2 nextVec = dirVec.normalized * ObjStatus.moveSpeed * Time.fixedDeltaTime; // �������� �̵�
        rigidHostile.MovePosition(rigidHostile.position + nextVec);
        rigidHostile.velocity = Vector2.zero; //�������� ����

    }

    void LateUpdate() //��� update�Լ� ȣ�� ���� ���������� ȣ���
    {
        if (ObjStatus.curHp == 0)
        {
            return;
        }
    }


}


