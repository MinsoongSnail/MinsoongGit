using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class inputCommand : MonoBehaviour
{
    /// <summary>
    /// ���⿡�ٰ� Ŀ�ǵ� ���� �Է��ϰ� hq, ally, hostile �Լ� ���� ����?
    /// </summary>
    public GameObject UI_LayoutControl; //UI ���̾ƿ� ��Ʈ�� ��ü
    public GameObject commandField; //��ǲ�ʵ� ���� ��ü(Ȱ��/��Ȱ��ȭ �����)
    public TMP_InputField inputField_Order;//��ǲ�ʵ�
    public GameObject hq_Obj;//HQ ��ü ���ÿ�
    public GameObject destination; //��ǥ �̵���

    public Vector3 coordinate;//�Է¹��� ��ǥ //�Է¹��� ������ ���ؾ���

    //��ɾ� ���
    string HQ = "hq";
    string ally = "ally";
    string move = "move";
    string make = "make";

    void Start()
    {
        destination.transform.position = coordinate;
    }

    void Update()
    {

        string orderText = inputField_Order.GetComponent<TMP_InputField>().text; //�Էµ� �ؽ�Ʈ �Ű�����

        //----�Ʊ� �̵�
        if (orderText == move && Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("�̵��Է¿Ϸ�");
        }
        
        //----���� ����
        if (orderText == HQ && Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("���� ���� �Ϸ�");
            GameManager.instance.selected_List.DeselectAll();
            GameManager.instance.selected_List.AddSelected(hq_Obj);
        }
        //----������ ���õ� ��쿡�� �Ʊ� ����
        if (orderText == make && Input.GetKeyDown(KeyCode.Return))
        { 
            if (GameManager.instance.selected_List.selected_Table.Contains(hq_Obj))
            {
                GameManager.instance.allySpawner.AllySpawn();  //�Ʊ�����
                Debug.Log("�����Է¿Ϸ�");
            }
            else //�ƴҰ�� �۵����� ����
            {
                    
            }         
        }
        //---- ���ڰ� ���Ե� ���ڿ�: �Ʊ����ð� ��ǥ���� ����
        if(orderText.Contains(ally) && Input.GetKeyDown(KeyCode.Return))//�Ʊ� ����       ex) ally1 �� �ԷµǸ�
        {
            string[] splitOrder = orderText.Split("ally"); // ally1 -> 1�� �����ϰ� allyNum�� ����
            string allyNum = splitOrder[1]; //�Ʊ��� ���� //ally�տ� ����""�� 0���� �����
            Debug.Log(allyNum + "���Ұ����");
            if (int.TryParse(allyNum, out int intAllyNum))
            {
                Debug.Log("�Ʊ� " + intAllyNum + " ���õ�");
                
                //----�Ʊ����� �˰���
                List<GameObject>[] AllyPools = GameManager.instance.poolAlly.AllyPools;
                int isAllyPools = GameManager.instance.poolAlly.AllyPools[0].Count;  //0������ �Ʊ��� ���� //���� : AllyPools[index] ���� index�� �Ʊ��� ����

                if ( (isAllyPools >= intAllyNum) && (intAllyNum > 0) ) //�Ʊ��� ���ڰ� �Է� ���ں��� ���ų� �Է¼��ڰ� 0���ϸ� �������� ����
                {
                    GameManager.instance.selected_List.DeselectAll();                              //����Ʈ �ʱ�ȭ
                    GameManager.instance.selected_List.AddSelected(AllyPools[0][intAllyNum - 1]); //n��Ŭ���� ���� ����Ʈ�� ����ֱ�
                }
                else
                {
                    GameManager.instance.selected_List.DeselectAll();//����Ʈ �ʱ�ȭ
                    Debug.Log("�ش� �Ʊ� �������� ����");
                }
                //----
            }
        }
        else //ally�� ���Ե��� ���� ���ڿ��� ���
        {
            if (orderText.Contains('x') && orderText.Contains('y') && Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("��ǥx ,��ǥy ���� �ν�");
                string[] splitOrder = orderText.Split(new char[] { 'x', 'y' });
                int.TryParse(splitOrder[1], out int xcoord);
                int.TryParse(splitOrder[2], out int ycoord);
                Debug.Log("��ǥx ,��ǥy " + xcoord + " " + ycoord + " �Էµ�");
                coordinate.x = xcoord;
                coordinate.y = ycoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else if (orderText.Contains("x") && Input.GetKeyDown(KeyCode.Return))
            {
                string[] splitOrder = orderText.Split('x');
                int.TryParse(splitOrder[1], out int xcoord);
                Debug.Log("��ǥx " + xcoord + " �Էµ�");
                coordinate.x = xcoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else if (orderText.Contains("y") && Input.GetKeyDown(KeyCode.Return))
            {
                string[] splitOrder = orderText.Split("y");
                int.TryParse(splitOrder[1], out int ycoord);
                Debug.Log("��ǥy " + ycoord + " �Էµ�");
                coordinate.y = ycoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else
            {

            }
        }
        //---- 
        if (Input.GetKeyUp(KeyCode.Return)) //���ͽ� ��ǲ�ʵ� Ŭ����
       {
           Debug.Log("�����Է¿Ϸ�");
           inputField_Order.GetComponent<TMP_InputField>().text = "";
       } 
       //----
    }
}

