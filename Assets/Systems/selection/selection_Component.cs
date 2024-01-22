using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class selection_Component : MonoBehaviour
{

    //�ڷ�ƾ Ȱ�밡��?
    Ally ally; //���� ������ ������Ʈ ���ٳ���
    Hq hq;

    void Start()
    {
        ally = GetComponent<Ally>();
        hq = GetComponent<Hq>();

        GetComponent<Renderer>().material.color = Color.red; //���뵿�� ���ý� ���� ����

        if (gameObject.CompareTag("Ally"))//�Ʊ� ���ý� 
        {
            ally.allySelected = true; //�Ʊ� ��ȣ�ۿ� Ȱ��ȭ 
        }
        
        if (gameObject.CompareTag("Hq"))//���� ���ý� 
        {
             hq.hqSelected = true;
        }
    }

    void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white; //���� ������ ���� ���� ���� �����

        if (gameObject.CompareTag("Ally"))//�Ʊ� ���ý� 
        {
            ally.allySelected = false; //�Ʊ� ���������� ����
            GameManager.instance.statusUI.frontText_1.text = string.Empty;
        }
        
        if (gameObject.CompareTag("Hq"))//���� ���ý� 
        {
            hq.hqSelected = false;
            GameManager.instance.statusUI.frontText_1.text = string.Empty;
        }
    }
}
