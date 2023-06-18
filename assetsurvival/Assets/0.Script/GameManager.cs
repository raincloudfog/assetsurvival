using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{
    public int level = 1; // 캐릭터 레벨
    public int Exp; // 플레이어 경험치
    int MaxExp = 100; // 레벨업 까지의 경험치량 
    public Player player;

    public GameObject waveClear; // 웨이브 끝날시
    public GameObject LevelUPUI; // 레벨업시 UI


    
    public void SetExp(int _Exp)
    {
        
        Exp += _Exp;
       
        if (Exp >= MaxExp)
        {
            Debug.Log("레벨업");
            level += 1;
            Exp = 0;
            MaxExp += level * 10;
            LevelUPUI.SetActive(true);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            waveClear.SetActive(true);
        }
    }
}
