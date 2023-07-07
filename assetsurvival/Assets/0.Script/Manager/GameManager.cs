using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMono<GameManager>
{
    public int level = 1; // 캐릭터 레벨
    public int Exp; // 플레이어 경험치
    int MaxExp = 100; // 레벨업 까지의 경험치량 
    public Player player;

    public GameObject waveClear; // 웨이브 끝날시
    public GameObject LevelUPUI; // 레벨업시 UI
    public GameObject Gamestop; // 일시정지

    public int WaveCount = 1; // 현재 몇웨이브인지
    public int ZombieKillCount = 0; // 좀비 몇마리 죽였는지
    public bool Clear = false; // 클리어 했는지

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
    ///  다시 게임으로
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
            Debug.Log("레벨업");
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
