using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;




public class ButtonManager : SingletonMono<ButtonManager>
{
    
    List<Button> Waepon_Buttons = new List<Button>();
    [Tooltip("������� �ִ� �� Ȯ���ϴ� ����")]
    public List<Weapons> weaPons = new List<Weapons>(); // ���Ⱑ �ִ��� Ȯ�ο뵵
    public Dictionary<Weapons, Weapon> Weapondic = new Dictionary<Weapons, Weapon>(); // ���Ⱑ ��� �׸�

    [Tooltip("������� �־��� ����")]
    public Weapon[] _Weapons; // ���� ����
    public Firepos firepos; // �ܰ� ������ ��ġ
    [SerializeField]Player player; // �÷��̾�
    [SerializeField] GameObject LevelUPUI; // �������� UI

    private void Start()
    {
        player = CharacterManager.Instance.MainPlayer;
    }
    /// <summary>
    /// ĳ���Ϳ��� �ظӸ� �ݴϴ�.
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
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);
            return;
        }

        Weapon obj = Instantiate(_Weapons[0]); // ������Ʈ Ǯ�� ���� �Ұ�
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        Weapondic.Add(Weapons.Hammer, obj);
        LevelUPUI.SetActive(false);// ����� ���ֱ�
    }
    /// <summary>
    /// �÷��̾�� ���� �ݴϴ�.
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
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);
            return;
        }
        Weapon obj = Instantiate(_Weapons[1]); // ������Ʈ Ǯ�� ���� �Ұ�
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
        Weapondic.Add(Weapons.Sword, obj);
        CharacterManager.Instance.MainPlayer_Rotate.rotateObj = obj.transform;
        LevelUPUI.SetActive(false); // ����� ���ֱ�
    }

    /// <summary>
    /// firepos�� �ܰ��� �ݴϴ�.
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
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);// ����� ���ֱ�
            
            return;
        }

        Weapon obj = Instantiate(_Weapons[2]); // ������Ʈ Ǯ�� �����Ұ�
        obj.Init();
        weaPons.Add(obj.weapons);
        
        Weapondic.Add(Weapons.Dagger, obj);

        Destroy(obj.gameObject);
        
        

        LevelUPUI.SetActive(false); // ����� ���ֱ�
    }


    public void OnHPPlus()
    {
        Debug.Log("ü������");
    }
    public void OnDamagePlus()
    {
        Debug.Log("������ ����");
    }
    public void CriticalPlus()
    {
        Debug.Log("ũ��Ƽ�� ������ ����");
    }
    public void CriticalChance()
    {
        Debug.Log("ũ��Ƽ�� �ۼ�Ʈ ����");
    }



}
