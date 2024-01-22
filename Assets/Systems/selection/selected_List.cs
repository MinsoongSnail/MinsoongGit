using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class selected_List : MonoBehaviour
{
    public List<GameObject> selected_Table = new List<GameObject>(); //선택 테이블 리스트

    public void AddSelected(GameObject obj)
    {
        selected_Table.Add(obj); //선택 테이블 딕셔너리 구조체에 id,오브젝트 추가
        obj.AddComponent<selection_Component>(); //오브젝트 색깔 변경(selection_Component 스크립트 참고)
        Debug.Log("빈 오브젝트 리스트에 선택됨"); //로그에 id 표시

    }
    public void DeselectAll() //id 제거 후 딕셔너리 구조체 비우기? obj에 부여된 컴포넌트 지우기? 
    {
        Debug.Log("선택 해제 됨");

        if (selected_Table.Count != 0)
        {
            foreach (GameObject obj in selected_Table)
            {
                if (obj.GetComponent<selection_Component>() != null) // 오브젝트에 selection_Component컴포넌트가 존재하면
                {
                    Destroy(selected_Table[0].GetComponent<selection_Component>());  //obj에 추가했던 selection_Component컴포넌트 제거
                }
            }
            selected_Table.Clear();//위 과정이 완료되면 리스트 비우기
        }
            
    }
}
