using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;




public class ButtonManager : SingletonMono<ButtonManager>
{
    
    List<Button> Waepon_Buttons = new List<Button>();
    public List<Weapons> weaPons = new List<Weapons>();

    public Weapon[] Weapons; // 무기 종류
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
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);// 진행시 꺼주기
            return;
        }
        Weapon obj = Instantiate(Weapons[0]); // 오브젝트 풀링 수정 할것
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        LevelUPUI.SetActive(false);// 진행시 꺼주기
    }
    /// <summary>
    /// 플레이어에게 검을 줍니다.
    /// </summary>
    public void OnSwordUI()
    {
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);
            return;
        }
        Weapon obj = Instantiate(Weapons[1]); // 오브젝트 풀링 수정 할것
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        CharacterManager.Instance.MainPlayer_Rotate.rotateObj = obj.transform;
        LevelUPUI.SetActive(false); // 진행시 꺼주기
    }

    /// <summary>
    /// firepos에 단검을 줍니다.
    /// </summary>
    public void OnDaggerUI()
    {
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
            LevelUPUI.SetActive(false);// 진행시 꺼주기
            return;
        }

        Weapon obj = Instantiate(Weapons[2]); // 오브젝트 풀링 수정할것
        obj.Init();
        weaPons.Add(obj.weapons);
        obj.gameObject.SetActive(false);

        LevelUPUI.SetActive(false); // 진행시 꺼주기
    }

}
