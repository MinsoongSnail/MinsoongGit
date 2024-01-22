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
        HostileSpawnPoint = GetComponentsInChildren<Transform>(); //0�� �ڱ� �ڽ��� ����Ų��
    }
    void HostileSpawn()
    {
            GameObject Hostile = GameManager.instance.poolHostile.Get(Hotile_level); //������ ���� ����
            Hostile.transform.position = HostileSpawnPoint[Random.Range(1, HostileSpawnPoint.Length)].position; //���� ��������Ʈ���� ����  
    }
    void Update()
    {
        HostileSpawnTimer += Time.deltaTime;//�ð� ���

        Hotile_level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f); //�Ҽ��� �Ʒ��� ������ int ������ �ٲ�

        if (Hotile_level > 1 )  //���� ����
        {
            Hotile_level = 1;
        }

        if(HostileSpawnTimer > (Hotile_level == 0 ? 1f : 0.4f))//�����ֱ�
        {
            HostileSpawn();
            HostileSpawnTimer = 0;
        }
    }
}
