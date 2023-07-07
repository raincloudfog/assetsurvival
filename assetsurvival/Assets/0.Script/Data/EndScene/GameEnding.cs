using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameEnd
{
    public string Clear;
    public int KillZombieCount;
    public int WaveCount;
}
public class GameEnding : MonoBehaviour
{

    [SerializeField] Text DidYouClear;
    [SerializeField] Text HowManyKillZomes;
    [SerializeField] Text HowManyWave;

    GameEnd gameEnd = new GameEnd();
    string path;
    string filename;
    // Start is called before the first frame update
    void Start()
    {
        path = path = Application.dataPath + "/";
        filename = "save.json";
        Load();
    }

    

    void Load()
    {
        GameEnd gameEnd = new GameEnd();

        string loadJson = File.ReadAllText(path + filename);
        gameEnd = JsonUtility.FromJson<GameEnd>(loadJson);

        if(gameEnd != null)
        {
            DidYouClear.text = gameEnd.Clear;
            HowManyKillZomes.text = gameEnd.KillZombieCount.ToString();
            HowManyWave.text = gameEnd.WaveCount.ToString();
        }
    }
}
