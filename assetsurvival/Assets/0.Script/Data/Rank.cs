using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class Rank : SingletonMono<Rank>
{

    private int highScore = 0; // �̰ų��߿� �������ƴ� ���̺�� ���� ������.
    public int HighScore
    {
        get
        {
            if (PlayerPrefs.HasKey("highScore"))
            {
                highScore = PlayerPrefs.GetInt("highScore", highScore);
            }
            return highScore;
        }
        set
        {

            highScore = value;
            PlayerPrefs.SetInt("highScore", highScore);
            Debug.Log(PlayerPrefs.GetInt("highScore", highScore));
        }
    }
} 
