using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum WeaponsButton
{
    Hammer,
    Sword,
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
    }
    
    private void OnEnable()
    {
        Time.timeScale = 0;
        randomint = checkint2();
        for (int i = 0; i < randomint.Count; i++)
        {
            Debug.Log(randomint[i]);
        }
        
        /*for (int i = 0; i < 3; i++)
        {
            
            WeaponsButton weaponsButton = (WeaponsButton)randomint[i];
            Button obj = Instantiate(Weapons[i]);
            obj.transform.SetParent(this.transform);
            
            
            obj.onClick.AddListener(Actions[weaponsButton]);
            buttons.Add(obj);
        }*/
        
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

    List<int> checkint() // 리스트에 인트 확인
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
    }

    List<int> checkint2()
    {
        List<int> aaaa = new List<int>() { 0, 1, 2 };
        List<int> shuffle = new List<int>();

        int idx = 0;

        count = aaaa.Count;
        for (int i = 0; i < count; i++)
        {
            idx = UnityEngine.Random.Range(0, aaaa.Count);
            shuffle.Add(aaaa[idx]);
            aaaa.RemoveAt(idx);
        }

        


        return shuffle;
        
    }
}
