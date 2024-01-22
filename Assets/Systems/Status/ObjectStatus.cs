using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus
{
    public ObjectCode ObjCode { get; }
        public string name { get; set; }
        public int maxHp { get; set; }
        public int curHp { get; set; }
        public float moveSpeed { get; set; }
        
    public ObjectStatus(ObjectCode ObjCode, string name, int maxHp, float moveSpeed) //������ �޼ҵ� �����ε�
    {
        this.ObjCode = ObjCode;
        this.name = name;
        this.maxHp = maxHp;
        curHp = maxHp;
        this.moveSpeed = moveSpeed;
    }

    public ObjectStatus() //������ �޼ҵ� : Ŭ������ �ν��Ͻ�ȭ(��ü)�Ǹ� �ڵ�����
    {
    }

    public ObjectStatus SetObjStatus(ObjectCode ObjCode) //������ �޼ҵ� �����ε�
    {
        ObjectStatus ObjStatus = null;

        switch(ObjCode) 
        {
            case ObjectCode.HQ:
                ObjStatus = new ObjectStatus(ObjCode, "HQ", 10 , 0f); 
                break;
            case ObjectCode.Ally1:
                ObjStatus = new ObjectStatus(ObjCode, "smallAlly", 1, 5.0f);
                break;
            case ObjectCode.Ally2:
                ObjStatus = new ObjectStatus(ObjCode, "middleAlly", 2, 4.0f);
                break;
            case ObjectCode.Ally3:
                ObjStatus = new ObjectStatus(ObjCode, "bigAlly", 3, 3.0f);
                break;
            case ObjectCode.Hostile1:
                ObjStatus = new ObjectStatus(ObjCode, "smallHostile", 1, 0.3f);
                break;
            case ObjectCode.Hostile2:
                ObjStatus = new ObjectStatus(ObjCode, "middleHostile", 2, 0.10f);
                break;
            case ObjectCode.Hostile3:
                ObjStatus = new ObjectStatus(ObjCode, "bigHostile", 3, 0.05f);
                break;

        }
        return ObjStatus;
    }

}
