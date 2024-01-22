using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //게임의 흐름 관리
  

    public float gameTime;  //게임시간
    public float maxGameTime; //최대 게임 시간

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
        gameTime += Time.deltaTime;//시간 기록

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime; 
        }
    }
}
