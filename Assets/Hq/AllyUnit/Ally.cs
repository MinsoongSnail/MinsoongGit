using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem; //��ǲ�ý���


public class Ally : MonoBehaviour
{
    //----�������ͽ� ����, ǥ��
    public ObjectCode ObjCode; //���� �ڵ� �ҷ������
    public ObjectStatus ObjStatus; //���� �ڵ�� ���� �ҷ�����

    //---- �Ʊ��� �ൿ�� ��ȣ�ۿ�
    Rigidbody2D rigid_Ally; //�Ʊ�
    private Vector3 targetPosition; //��ǥ ��ġ

    //---- �Ʊ� ���ÿ���
    public bool allySelected; //���õ� ������Ʈ ����

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //������ �޼ҵ�
        ObjStatus = ObjStatus.SetObjStatus(ObjectCode.Ally1); //������ �޼ҵ忡�� SetObjStatus�Լ� ȣ��
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) �� ���ٷ� ������

        rigid_Ally = GetComponent<Rigidbody2D>();
    }
     void Start()
    {
        targetPosition = transform.position; //��ǥ��ġ
    }

    void Update()
    {
        //----�Ʊ� �������ͽ� ����
       switch(ObjStatus.curHp)
        {
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                AllyLevel(1);
                ObjStatus.curHp = 1; //�ʿ�?
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

        //----�Ʊ� �̵�
        string orderText = GameManager.instance.inputCommand.inputField_Order.GetComponent<TMP_InputField>().text; //�Էµ� �ؽ�Ʈ �Ű�����
        if (orderText == "move" && Input.GetKeyDown(KeyCode.Return)&& allySelected)
        {
            Debug.Log("�̵��Է¿Ϸ�");
            targetPosition = GameManager.instance.inputCommand.coordinate; //��ǥ��ġ�� �޾ƿ�
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, ObjStatus.moveSpeed * Time.deltaTime); //�̵��Լ� 
        
        //----���ý� ����ǥ��
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
