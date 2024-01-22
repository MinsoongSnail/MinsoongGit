using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class selection_Global : MonoBehaviour
{
    selected_List selected_Table; //selected_Dictionary ��ũ��Ʈ ��������

    //����ĳ��Ʈ
    RaycastHit2D hit;

    //����ĳ��Ʈ 3d�� 2d�� �ٲ����??
    Vector3 mousePos1; //���콺 �ٿ�� ���콺 ��ġ

    void Start()
    {
        selected_Table = GetComponent<selected_List>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 ��ư�� �������� (not released)
        {
            Vector3 mousePos3 = Camera.main.WorldToScreenPoint(Input.mousePosition); //ScreenToWorldPoint�� z��ǥ�� ��� ī�޶���ġ�� �����̵�??
            mousePos1 = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition).x,(Input.mousePosition).y, mousePos3.z)); //ù Ŭ�� ��ǥ
        }

        if (Input.GetMouseButtonUp(0)) //���콺 ��ư�� ����������
        {
            if (EventSystem.current.IsPointerOverGameObject()) //UI Ŭ���� ����ĳ��Ʈ ����
            {
                return;
            }
            hit = Physics2D.Raycast(mousePos1, Vector2.zero, 0f);

                if (hit) //����ĳ��Ʈ�� ��� Ž��
                {
                    Debug.Log("���콺�� ��� ���õ�");
                    selected_Table.DeselectAll(); //������ �ִ��� �����
                    selected_Table.AddSelected(hit.transform.gameObject);//������Ʈ��ǥ�� ���̺� �߰�
                }
                else //����ĳ��Ʈ�� ����� Ž���ߴµ� ������Ʈ�� ���ٸ�
                {
                    selected_Table.DeselectAll();
                }
        }

    }
}
