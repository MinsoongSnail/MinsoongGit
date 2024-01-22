using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHostile : MonoBehaviour
{
    //������ ���� ����  - ����Ʈ�� 1��1
    public GameObject[] HostilePrefabs;
    //Ǯ ��� ����Ʈ    - ������ 1��1
    List<GameObject>[] HostilePools;

    void Awake()
    {
        HostilePools = new List<GameObject>[HostilePrefabs.Length]; //����Ʈ �ʱ�ȭ

        for (int index =0; index < HostilePools.Length; index++) //����Ʈ ��� ���� �ʱ�ȭ
        {
            HostilePools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)//������Ʈ ��ȯ
    {
        GameObject select = null;
        // ���� Ǯ ������Ʈ ����
        foreach(GameObject item in HostilePools[index]) //����Ʈ ������ ��ȸ�ݺ��� ����� ��Ҵ� ������ �Ҵ�
        {
            if (item.activeSelf==false)// ����(��Ȱ��ȭ) ������Ʈ �߽߰� select�� �Ҵ�
            {
                select = item;
                select.SetActive(true);
                break;  //�߽߰� ��ȸ ����
            }
        }
        // ������ ���� �����ؼ� select�� �Ҵ� 
        if(select == null)
        {
            select = Instantiate(HostilePrefabs[index], transform);  //���� ������Ʈ�� �����ؼ� ��鿡 �����ϴ� �Լ�
            HostilePools[index].Add(select);         //pool�� �߰�
        }
        return select;
    }
}
