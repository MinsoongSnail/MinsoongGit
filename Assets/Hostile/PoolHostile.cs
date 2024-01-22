using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHostile : MonoBehaviour
{
    //프리팹 보관 변수  - 리스트와 1대1
    public GameObject[] HostilePrefabs;
    //풀 담당 리스트    - 변수와 1대1
    List<GameObject>[] HostilePools;

    void Awake()
    {
        HostilePools = new List<GameObject>[HostilePrefabs.Length]; //리스트 초기화

        for (int index =0; index < HostilePools.Length; index++) //리스트 요소 전부 초기화
        {
            HostilePools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)//오브젝트 반환
    {
        GameObject select = null;
        // 선택 풀 오브젝트 접근
        foreach(GameObject item in HostilePools[index]) //리스트 데이터 순회반복문 출력할 요소는 변수로 할당
        {
            if (item.activeSelf==false)// 쉬는(비활성화) 오브젝트 발견시 select에 할당
            {
                select = item;
                select.SetActive(true);
                break;  //발견시 순회 종료
            }
        }
        // 없으면 새로 생성해서 select에 할당 
        if(select == null)
        {
            select = Instantiate(HostilePrefabs[index], transform);  //원본 오브젝트를 복제해서 장면에 생성하는 함수
            HostilePools[index].Add(select);         //pool에 추가
        }
        return select;
    }
}
