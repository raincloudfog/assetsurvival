using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{
    public int level = 1; // ĳ���� ����
    public int Exp; // �÷��̾� ����ġ
    int MaxExp = 100; // ������ ������ ����ġ�� 
    public Player player;

    public GameObject waveClear; // ���̺� ������
    public GameObject LevelUPUI; // �������� UI


    
    public void SetExp(int _Exp)
    {
        
        Exp += _Exp;
       
        if (Exp >= MaxExp)
        {
            Debug.Log("������");
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
