using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;




public class ButtonManager : SingletonMono<ButtonManager>
{
    
    List<Button> Waepon_Buttons = new List<Button>();
    [Tooltip("무기들이 있는 지 확인하는 공간")]
    public List<Weapons> weaPons = new List<Weapons>(); // 무기가 있는지 확인용도
    public Dictionary<Weapons, Weapon> Weapondic = new Dictionary<Weapons, Weapon>(); // 무기가 담길 그릇

    [Tooltip("무기들을 넣어줄 공간")]
    public Weapon[] _Weapons; // 무기 종류
    public Firepos firepos; // 단검 나가는 위치
    [SerializeField]Player player; // 플레이어
    [SerializeField] GameObject LevelUPUI; // 레벨업시 UI

    private void Start()
    {
        player = CharacterManager.Instance.MainPlayer;
    }
    /// <summary>
    /// 캐릭터에게 해머를 줍니다.
    /// </summary>
    public void OnHammerUI()
    {
        if (Weapondic.ContainsKey(Weapons.Hammer) == true)
        {
            WeaponManager.Instance.HammerPowerUp(5);
            Debug.Log(WeaponManager.Instance.Hammerdamage);
            LevelUPUI.SetActive(false);
            return;
        }
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);
            return;
        }

        Weapon obj = Instantiate(_Weapons[0]); // 오브젝트 풀링 수정 할것
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        Weapondic.Add(Weapons.Hammer, obj);
        LevelUPUI.SetActive(false);// 진행시 꺼주기
    }
    /// <summary>
    /// 플레이어에게 검을 줍니다.
    /// </summary>
    public void OnSwordUI()
    {
        if (Weapondic.ContainsKey(Weapons.Sword) == true)
        {
            WeaponManager.Instance.SwordPowerUp(5);
            Debug.Log(WeaponManager.Instance.Sworddamage);
            LevelUPUI.SetActive(false);
            return;
        }

        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);
            return;
        }
        Weapon obj = Instantiate(_Weapons[1]); // 오브젝트 풀링 수정 할것
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        Weapondic.Add(Weapons.Sword, obj);
        CharacterManager.Instance.MainPlayer_Rotate.rotateObj = obj.transform;
        LevelUPUI.SetActive(false); // 진행시 꺼주기
    }

    /// <summary>
    /// firepos에 단검을 줍니다.
    /// </summary>
    public void OnDaggerUI()
    {
        if (Weapondic.ContainsKey(Weapons.Dagger) == true)
        {
            WeaponManager.Instance.DaggerPowerUp(5);
            Debug.Log(WeaponManager.Instance.Daggerdamage);
            LevelUPUI.SetActive(false);
            return;
        }

        else if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);// 진행시 꺼주기
            
            return;
        }

        Weapon obj = Instantiate(_Weapons[2]); // 오브젝트 풀링 수정할것
        obj.Init();
        weaPons.Add(obj.weapons);
        
        Weapondic.Add(Weapons.Dagger, obj);

        Destroy(obj.gameObject);
        
        

        LevelUPUI.SetActive(false); // 진행시 꺼주기
    }


    public void OnHPPlus()
    {
        Debug.Log("체력증가");
    }
    public void OnDamagePlus()
    {
        Debug.Log("데미지 증가");
    }
    public void CriticalPlus()
    {
        Debug.Log("크리티컬 데미지 증가");
    }
    public void CriticalChance()
    {
        Debug.Log("크리티컬 퍼센트 증가");
    }



}
