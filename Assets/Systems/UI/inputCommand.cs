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
    /// 여기에다가 커맨드 전부 입력하고 hq, ally, hostile 함수 만들어서 정리?
    /// </summary>
    public GameObject UI_LayoutControl; //UI 레이아웃 컨트롤 객체
    public GameObject commandField; //인풋필드 상위 객체(활성/비활성화 제어용)
    public TMP_InputField inputField_Order;//인풋필드
    public GameObject hq_Obj;//HQ 객체 선택용
    public GameObject destination; //목표 이동용

    public Vector3 coordinate;//입력받은 좌표 //입력받을 형식을 정해야함

    //명령어 목록
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

        string orderText = inputField_Order.GetComponent<TMP_InputField>().text; //입력된 텍스트 매개변수

        //----아군 이동
        if (orderText == move && Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("이동입력완료");
        }
        
        //----본진 선택
        if (orderText == HQ && Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("본부 선택 완료");
            GameManager.instance.selected_List.DeselectAll();
            GameManager.instance.selected_List.AddSelected(hq_Obj);
        }
        //----본진이 선택된 경우에만 아군 생성
        if (orderText == make && Input.GetKeyDown(KeyCode.Return))
        { 
            if (GameManager.instance.selected_List.selected_Table.Contains(hq_Obj))
            {
                GameManager.instance.allySpawner.AllySpawn();  //아군생성
                Debug.Log("생성입력완료");
            }
            else //아닐경우 작동하지 않음
            {
                    
            }         
        }
        //---- 숫자가 포함된 문자열: 아군선택과 좌표선택 구분
        if(orderText.Contains(ally) && Input.GetKeyDown(KeyCode.Return))//아군 선택       ex) ally1 이 입력되면
        {
            string[] splitOrder = orderText.Split("ally"); // ally1 -> 1로 변경하고 allyNum에 저장
            string allyNum = splitOrder[1]; //아군의 숫자 //ally앞에 공백""이 0번에 저장됨
            Debug.Log(allyNum + "분할결과물");
            if (int.TryParse(allyNum, out int intAllyNum))
            {
                Debug.Log("아군 " + intAllyNum + " 선택됨");
                
                //----아군선택 알고리즘
                List<GameObject>[] AllyPools = GameManager.instance.poolAlly.AllyPools;
                int isAllyPools = GameManager.instance.poolAlly.AllyPools[0].Count;  //0번종류 아군의 수량 //참조 : AllyPools[index] 에서 index는 아군의 종류

                if ( (isAllyPools >= intAllyNum) && (intAllyNum > 0) ) //아군의 숫자가 입력 숫자보다 적거나 입력숫자가 0이하면 실행하지 않음
                {
                    GameManager.instance.selected_List.DeselectAll();                              //리스트 초기화
                    GameManager.instance.selected_List.AddSelected(AllyPools[0][intAllyNum - 1]); //n번클론을 선택 리스트에 집어넣기
                }
                else
                {
                    GameManager.instance.selected_List.DeselectAll();//리스트 초기화
                    Debug.Log("해당 아군 존재하지 않음");
                }
                //----
            }
        }
        else //ally가 포함되지 않은 문자열일 경우
        {
            if (orderText.Contains('x') && orderText.Contains('y') && Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("좌표x ,좌표y 동시 인식");
                string[] splitOrder = orderText.Split(new char[] { 'x', 'y' });
                int.TryParse(splitOrder[1], out int xcoord);
                int.TryParse(splitOrder[2], out int ycoord);
                Debug.Log("좌표x ,좌표y " + xcoord + " " + ycoord + " 입력됨");
                coordinate.x = xcoord;
                coordinate.y = ycoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else if (orderText.Contains("x") && Input.GetKeyDown(KeyCode.Return))
            {
                string[] splitOrder = orderText.Split('x');
                int.TryParse(splitOrder[1], out int xcoord);
                Debug.Log("좌표x " + xcoord + " 입력됨");
                coordinate.x = xcoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else if (orderText.Contains("y") && Input.GetKeyDown(KeyCode.Return))
            {
                string[] splitOrder = orderText.Split("y");
                int.TryParse(splitOrder[1], out int ycoord);
                Debug.Log("좌표y " + ycoord + " 입력됨");
                coordinate.y = ycoord;
                coordinate.z = transform.position.z;
                destination.transform.position = coordinate;
            }
            else
            {

            }
        }
        //---- 
        if (Input.GetKeyUp(KeyCode.Return)) //엔터시 인풋필드 클리어
       {
           Debug.Log("엔터입력완료");
           inputField_Order.GetComponent<TMP_InputField>().text = "";
       } 
       //----
    }
}

