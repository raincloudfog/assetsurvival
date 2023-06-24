using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEntity : MonoBehaviour
{
    static int m_iNextValidID = 0;

    int id;
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
            m_iNextValidID++;
        }        
    }

    string entityNmae; //에이전트 이름
    string personalColor; // 에이전트 석상 ( 텍스트 출력용)

    /// <summary>
    /// 파생 클래스에서 base.Setup()으로 호출
    /// </summary>
    public virtual void SetUp(string name)
    {
        //고유 번호 설정
        ID = m_iNextValidID;
        //이름 설정
        entityNmae = name;
        int color = Random.Range(0, 1000000);
        personalColor = $"#{color.ToString("X6")}";
    }
    // GameController클래스에서 모든 에이전트의 UPdate()를 호출해 에이전트를 구동한다.
    public abstract void Updated();

    /// <summary>
    /// Console View에 [이름 : 대사] 출력
    /// </summary>
    /// <param name="text"></param>
    public void PrintText(string text)
    {
        Debug.Log($"<Color={personalColor}><b>{entityNmae}</b></color> : {text}");
    }
    
}
