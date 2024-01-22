using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAlly : MonoBehaviour
{
    //������ ���� ����  - ����Ʈ�� 1��1
    public GameObject[] AllyPrefabs;

    //Ǯ ��� ����Ʈ    - ������ 1��1
    public List<GameObject>[] AllyPools;

    void Awake()
    {
        AllyPools = new List<GameObject>[AllyPrefabs.Length]; //����Ʈ �ʱ�ȭ

        for (int index = 0; index < AllyPools.Length; index++) //����Ʈ ��� ���� �ʱ�ȭ
        {
            AllyPools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)//������Ʈ ��ȯ
    {
        GameObject select = null;
        // ���� Ǯ ������Ʈ ����
        foreach (GameObject item in AllyPools[index]) //����Ʈ ������ ��ȸ�ݺ��� ����� ��Ҵ� ������ �Ҵ�
        {
            if (item.activeSelf == false)// ����(��Ȱ��ȭ) ������Ʈ �߽߰� select�� �Ҵ�
            {
                select = item;
                select.SetActive(true);
                break;  //�߽߰� ��ȸ ����
            }
        }
        // ������ ���� �����ؼ� select�� �Ҵ�  
        if (select == null)
        {
            select = Instantiate(AllyPrefabs[index], transform);  //���� ������Ʈ�� �����ؼ� ��鿡 �����ϴ� �Լ�
            AllyPools[index].Add(select);         //pool�� �߰�
        }
        return select;
    }

}
