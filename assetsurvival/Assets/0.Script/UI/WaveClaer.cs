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
    public stat _stat; // 버튼을 바꿔주기위한 enum
    public Image _img; // 이미지
    public string _StatName; // 스탯 이름
    public string _Stattxt; // 스탯 증가폭
}


public class WaveClaer : MonoBehaviour
{

    List<int> randomint = new List<int>(); // 랜덤한 숫자들
    [SerializeField] Button statsButton;
    Dictionary<stat, UnityEngine.Events.UnityAction> Actions =
        new Dictionary<stat, UnityEngine.Events.UnityAction>(); // 버튼에 들어갈 버튼 기능들

    
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
        Time.timeScale = 0; // 활성화시 시간을 멈춘다.
        randomint = checkint(); // 체크 인트를 통해 랜덤한 숫자들을 입력 받습니다.
        for (int i = 0; i < randomint.Count; i++) // 랜덤 인트의 숫자들 만큼 만들려면 카운트 사용
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
    /// 숫자를 랜덤으로 만들어서 전달해주는 함수
    /// </summary>
    /// <returns></returns>
    List<int> checkint() 
    {
        List<int> Numbers = new List<int>() { 0,1,2 }; // 기본 리스트 숫자들
        List<int> shuffle = new List<int>(); // 위의 리스트들의 섞인값들

        int idx = 0;
        int count;
        count = Numbers.Count; // numbers의 개수

        for (int i = 0; i < count; i++)
        {
            idx = Random.Range(0, Numbers.Count);
            shuffle.Add(Numbers[idx]);
            Numbers.RemoveAt(idx);
        }
        return shuffle;
    }

}
