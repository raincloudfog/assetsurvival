using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMono<GameManager>
{
    public int level = 1; // ĳ���� ����
    public int Exp; // �÷��̾� ����ġ
    int MaxExp = 100; // ������ ������ ����ġ�� 
    public Player player;

    public GameObject waveClear; // ���̺� ������
    public GameObject LevelUPUI; // �������� UI
    public GameObject Gamestop; // �Ͻ�����

    public int WaveCount = 1; // ���� ����̺�����
    public int ZombieKillCount = 0; // ���� ��� �׿�����
    public bool Clear = false; // Ŭ���� �ߴ���

    GameEnd gameEnd = new GameEnd();

    string path;
    string filename;

    public void Awake()
    {
        path = Application.dataPath + "/";
        filename = "save.json";
        InPutManager.Instance.AddKeycode(KeyCode.Escape, OpenGamestop);
    }

    void OpenGamestop()
    {
        Gamestop.SetActive(true);
        Time.timeScale = 0;
        InPutManager.Instance.AddKeycode(KeyCode.Escape, OnCloseGameStope);

    }
    /// <summary>
    ///  �ٽ� ��������
    /// </summary>
    public void OnCloseGameStope()
    {
        Gamestop.SetActive(false);
        Time.timeScale = 1;
        InPutManager.Instance.AddKeycode(KeyCode.Escape, OpenGamestop);
    }
    
    public void Save()
    {
        gameEnd.Clear = Clear ? "Yes" : "No";
        gameEnd.KillZombieCount = ZombieKillCount;
        gameEnd.WaveCount = WaveCount;

        string data = JsonUtility.ToJson(gameEnd);

        File.WriteAllText(path + filename, data);

        SceneManager.LoadScene(2);
    }

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
        /*if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            waveClear.SetActive(true);
        }*/
    }
}
