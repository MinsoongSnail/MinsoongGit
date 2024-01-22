using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class selected_List : MonoBehaviour
{
    public List<GameObject> selected_Table = new List<GameObject>(); //���� ���̺� ����Ʈ

    public void AddSelected(GameObject obj)
    {
        selected_Table.Add(obj); //���� ���̺� ��ųʸ� ����ü�� id,������Ʈ �߰�
        obj.AddComponent<selection_Component>(); //������Ʈ ���� ����(selection_Component ��ũ��Ʈ ����)
        Debug.Log("�� ������Ʈ ����Ʈ�� ���õ�"); //�α׿� id ǥ��

    }
    public void DeselectAll() //id ���� �� ��ųʸ� ����ü ����? obj�� �ο��� ������Ʈ �����? 
    {
        Debug.Log("���� ���� ��");

        if (selected_Table.Count != 0)
        {
            foreach (GameObject obj in selected_Table)
            {
                if (obj.GetComponent<selection_Component>() != null) // ������Ʈ�� selection_Component������Ʈ�� �����ϸ�
                {
                    Destroy(selected_Table[0].GetComponent<selection_Component>());  //obj�� �߰��ߴ� selection_Component������Ʈ ����
                }
            }
            selected_Table.Clear();//�� ������ �Ϸ�Ǹ� ����Ʈ ����
        }
            
    }
}
