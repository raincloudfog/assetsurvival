using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum WeaponsButton
{
    Hammer,
    Sword,
    Dagger,
    Axe
}
public class LevelUp : MonoBehaviour
{

    List<int> randomint = new List<int>();
    [SerializeField]Button[] Weapons;
    public List<Button> buttons = new List<Button>(); // 버튼 담는 그릇
    Dictionary<WeaponsButton, UnityEngine.Events.UnityAction> Actions =
        new Dictionary<WeaponsButton, UnityEngine.Events.UnityAction>();

    int count;

    private void Awake()
    {
        Actions.Add(WeaponsButton.Hammer, ButtonManager.Instance.OnHammerUI);
        Actions.Add(WeaponsButton.Sword, ButtonManager.Instance.OnSwordUI);
        Actions.Add(WeaponsButton.Dagger, ButtonManager.Instance.OnDaggerUI);
    }
    
    private void OnEnable() // 활성화 될시
    {
        Time.timeScale = 0; // 시간을 멈추고
        randomint = checkint2(); //랜덤 인트 값 넣어주고
        for (int i = 0; i < randomint.Count; i++) // 랜덤인트값의 카운트수만큼
        {
            Debug.Log(randomint[i]);

            WeaponsButton weaponsButton = (WeaponsButton)randomint[i]; 
            Button obj = Instantiate(Weapons[randomint[i]]);
            obj.transform.SetParent(this.transform);


            obj.onClick.AddListener(Actions[weaponsButton]);
            buttons.Add(obj);
        }                       
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1;
        randomint.Clear();
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        buttons.Clear();
    }

    /*List<int> checkint() // 리스트에 인트 확인
    {
        List<int> list = new List<int>();
        while(true)
        {
            int a = UnityEngine.Random.Range(0, Weapons.Length);
            
            if (list.Contains(a))
            {
                a = UnityEngine.Random.Range(0, Weapons.Length);
            }
            else
            {
                list.Add(a);
                
            }
            if(list.Count == 3)
            {
                break;
            }
        }
        
        
        return list;
    }*/

    List<int> checkint2()
    {
        List<int> aaaa = new List<int>() { 0, 1, 2 }; // 이 안에 있는 숫자를 뺄겁니다.
        List<int> shuffle = new List<int>(); // 섞어주는 용도입니다.

        int idx = 0;

        count = aaaa.Count; //aaa의 개수
        for (int i = 0; i < count; i++) 
        {
            idx = UnityEngine.Random.Range(0, aaaa.Count);
            shuffle.Add(aaaa[idx]);
            aaaa.RemoveAt(idx);
        }        
        return shuffle;
        
    }
}
