using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //������ �帧 ����
  

    public float gameTime;  //���ӽð�
    public float maxGameTime; //�ִ� ���� �ð�

    public PoolHostile poolHostile;
    public PoolAlly poolAlly;
    public AllySpawner allySpawner;

    public Hq Hq;
    public Ally ally;

    public selected_List selected_List;

    public inputCommand inputCommand;

    public statusUI statusUI;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;//�ð� ���

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime; 
        }
    }
}
