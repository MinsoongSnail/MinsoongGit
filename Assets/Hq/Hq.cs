using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hq : MonoBehaviour
{
    
    //----�������ͽ� ����, ǥ��
    public ObjectCode ObjCode; //���� �ڵ� �ҷ������
    public ObjectStatus ObjStatus; //���� �ڵ�� ���� �ҷ�����

    //---- ������ �ൿ�� ��ȣ�ۿ�
    Rigidbody2D rigid_Hq;

    //---- ���� ���ÿ���
    public bool hqSelected; //���õ� ������Ʈ ����

    void Awake()
    {
        ObjStatus = new ObjectStatus(); //������ �޼ҵ�
        ObjStatus = ObjStatus.SetObjStatus(ObjCode); //������ �޼ҵ忡�� SetObjStatus�Լ� ȣ��
        //  ==  ObjStatus = new ObjectStatus().SetObjStatus(ObjCode) �� ���ٷ� ������

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
