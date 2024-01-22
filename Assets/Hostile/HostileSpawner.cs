using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    public Transform[] HostileSpawnPoint;

    int Hotile_level;

    float HostileSpawnTimer;



     void Awake()
    {
        HostileSpawnPoint = GetComponentsInChildren<Transform>(); //0은 자기 자신을 가리킨다
    }
    void HostileSpawn()
    {
            GameObject Hostile = GameManager.instance.poolHostile.Get(Hotile_level); //레벨에 따라 스폰
            Hostile.transform.position = HostileSpawnPoint[Random.Range(1, HostileSpawnPoint.Length)].position; //랜덤 스폰포인트에서 스폰  
    }
    void Update()
    {
        HostileSpawnTimer += Time.deltaTime;//시간 기록

        Hotile_level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f); //소수점 아래는 버리고 int 형으로 바꿈

        if (Hotile_level > 1 )  //레벨 제한
        {
            Hotile_level = 1;
        }

        if(HostileSpawnTimer > (Hotile_level == 0 ? 1f : 0.4f))//스폰주기
        {
            HostileSpawn();
            HostileSpawnTimer = 0;
        }
    }
}
