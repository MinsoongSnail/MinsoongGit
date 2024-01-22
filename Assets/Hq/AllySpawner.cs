using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public Rigidbody2D AllySpawnPoint;

    void OnEnable()
    {
        AllySpawnPoint = GameManager.instance.Hq.GetComponent<Rigidbody2D>(); //HQ위치
    }
    public void AllySpawn()
    {
        GameObject Ally = GameManager.instance.poolAlly.Get(0); //스폰
        Ally.transform.position = AllySpawnPoint.position;
    }

}
