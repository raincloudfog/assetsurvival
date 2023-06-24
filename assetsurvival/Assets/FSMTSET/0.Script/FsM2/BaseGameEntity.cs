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

    string entityNmae; //������Ʈ �̸�
    string personalColor; // ������Ʈ ���� ( �ؽ�Ʈ ��¿�)

    /// <summary>
    /// �Ļ� Ŭ�������� base.Setup()���� ȣ��
    /// </summary>
    public virtual void SetUp(string name)
    {
        //���� ��ȣ ����
        ID = m_iNextValidID;
        //�̸� ����
        entityNmae = name;
        int color = Random.Range(0, 1000000);
        personalColor = $"#{color.ToString("X6")}";
    }
    // GameControllerŬ�������� ��� ������Ʈ�� UPdate()�� ȣ���� ������Ʈ�� �����Ѵ�.
    public abstract void Updated();

    /// <summary>
    /// Console View�� [�̸� : ���] ���
    /// </summary>
    /// <param name="text"></param>
    public void PrintText(string text)
    {
        Debug.Log($"<Color={personalColor}><b>{entityNmae}</b></color> : {text}");
    }
    
}
