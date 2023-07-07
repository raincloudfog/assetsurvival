using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum stat
{
    HP,
    Damage,
    CriticalPlus,
    CriticalChance,
    End
}

[System.Serializable]
public class StatPlus
{
    public stat _stat; // ��ư�� �ٲ��ֱ����� enum
    public Image _img; // �̹���
    public string _StatName; // ���� �̸�
    public string _Stattxt; // ���� ������
}


public class WaveClaer : MonoBehaviour
{

    List<int> randomint = new List<int>(); // ������ ���ڵ�
    [SerializeField] Button statsButton;
    Dictionary<stat, UnityEngine.Events.UnityAction> Actions =
        new Dictionary<stat, UnityEngine.Events.UnityAction>(); // ��ư�� �� ��ư ��ɵ�

    
    public List<StatPlus> stats = new List<StatPlus>();

    private void Awake()
    {
        Actions.Add(stat.HP, ButtonManager.Instance.OnHPPlus);
        Actions.Add(stat.Damage, ButtonManager.Instance.OnDamagePlus);
        /*Actions.Add(stat.CriticalChance, ButtonManager.Instance.CriticalChance);*/
        Actions.Add(stat.CriticalPlus, ButtonManager.Instance.CriticalPlus);
    }

    private void OnEnable()
    {
        Time.timeScale = 0; // Ȱ��ȭ�� �ð��� �����.
        randomint = checkint(); // üũ ��Ʈ�� ���� ������ ���ڵ��� �Է� �޽��ϴ�.
        for (int i = 0; i < randomint.Count; i++) // ���� ��Ʈ�� ���ڵ� ��ŭ ������� ī��Ʈ ���
        {
            stat _stat = (stat)randomint[i];
            
            Button obj = Instantiate(statsButton, transform);
            obj.GetComponent<StatButton>().Init(stats[randomint[i]]);
            obj.onClick.AddListener(Actions[_stat]);
        }


    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        randomint.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
    }


    /// <summary>
    /// ���ڸ� �������� ���� �������ִ� �Լ�
    /// </summary>
    /// <returns></returns>
    List<int> checkint() 
    {
        List<int> Numbers = new List<int>() { 0,1,2 }; // �⺻ ����Ʈ ���ڵ�
        List<int> shuffle = new List<int>(); // ���� ����Ʈ���� ���ΰ���

        int idx = 0;
        int count;
        count = Numbers.Count; // numbers�� ����

        for (int i = 0; i < count; i++)
        {
            idx = Random.Range(0, Numbers.Count);
            shuffle.Add(Numbers[idx]);
            Numbers.RemoveAt(idx);
        }
        return shuffle;
    }

}
