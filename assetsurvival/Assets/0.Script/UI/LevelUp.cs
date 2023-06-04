using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum WeaponsButton
{
    Hammer,
    Sword,

}
public class LevelUp : MonoBehaviour
{
    

    [SerializeField]Button[] Weapons;
    public List<Button> buttons = new List<Button>(); // 버튼 담는 그릇
    Dictionary<WeaponsButton, UnityEngine.Events.UnityAction> Actions =
        new Dictionary<WeaponsButton, UnityEngine.Events.UnityAction>();

    private void Awake()
    {
        Actions.Add(WeaponsButton.Hammer, ButtonManager.Instance.OnHammerUI);
        Actions.Add(WeaponsButton.Sword, ButtonManager.Instance.OnSwordUI);
    }
    
    private void OnEnable()
    {
        Time.timeScale = 0;
        for (int i = 0; i < Weapons.Length; i++)
        {
            int weaponsCount = UnityEngine.Random.Range(0, Weapons.Length);
            WeaponsButton weaponsButton = (WeaponsButton)weaponsCount;
            Button obj = Instantiate(Weapons[weaponsCount]);
            obj.transform.SetParent(this.transform);
            
            
            obj.onClick.AddListener(Actions[weaponsButton]);
            buttons.Add(obj);
        }
        
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1;
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        buttons.Clear();
    }
}
