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
    public List<Button> buttons = new List<Button>(); // ��ư ��� �׸�
    Dictionary<WeaponsButton, UnityEngine.Events.UnityAction> Actions =
        new Dictionary<WeaponsButton, UnityEngine.Events.UnityAction>();

    int count;

    private void Awake()
    {
        Actions.Add(WeaponsButton.Hammer, ButtonManager.Instance.OnHammerUI);
        Actions.Add(WeaponsButton.Sword, ButtonManager.Instance.OnSwordUI);
        Actions.Add(WeaponsButton.Dagger, ButtonManager.Instance.OnDaggerUI);
    }
    
    private void OnEnable() // Ȱ��ȭ �ɽ�
    {
        Time.timeScale = 0; // �ð��� ���߰�
        randomint = checkint2(); //���� ��Ʈ �� �־��ְ�
        for (int i = 0; i < randomint.Count; i++) // ������Ʈ���� ī��Ʈ����ŭ
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

    /*List<int> checkint() // ����Ʈ�� ��Ʈ Ȯ��
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
        List<int> aaaa = new List<int>() { 0, 1, 2 }; // �� �ȿ� �ִ� ���ڸ� ���̴ϴ�.
        List<int> shuffle = new List<int>(); // �����ִ� �뵵�Դϴ�.

        int idx = 0;

        count = aaaa.Count; //aaa�� ����
        for (int i = 0; i < count; i++) 
        {
            idx = UnityEngine.Random.Range(0, aaaa.Count);
            shuffle.Add(aaaa[idx]);
            aaaa.RemoveAt(idx);
        }        
        return shuffle;
        
    }
}
