using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{
    public int level = 1; // ĳ���� ����
    public int Exp; // �÷��̾� ����ġ
    int MaxExp = 100; // ������ ������ ����ġ�� 

    public GameObject LevelUPUI; // �������� UI


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Exp >= MaxExp)
        {
            level += 1;
            Exp = 0;
            MaxExp += level * 10;
            LevelUPUI.SetActive(true);
        }
        else
        {
            //LevelUPUI.SetActive(false);
        }
    }
}
