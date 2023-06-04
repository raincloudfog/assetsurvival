using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class ButtonManager : SingletonMono<ButtonManager>
{
    List<Button> Waepon_Buttons = new List<Button>();
    List<Weapon> weaPons = new List<Weapon>();
    public Weapon[] Weapons;
    [SerializeField]Player player;
    [SerializeField] GameObject LevelUPUI; // �������� UI

    private void Start()
    {
        switch (CharacterManager.Instance.character_type)
        {
            case Character.UnityChan:
                player = FindObjectOfType<UnityChan>();
                break;
            case Character.Misaki:
                player = FindObjectOfType<Misaki>();
                break;
            case Character.Yuko:
                player = FindObjectOfType<Yuko>();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// ĳ���Ϳ��� �ظӸ� �ݴϴ�.
    /// </summary>
    public void OnHammerUI()
    {
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);// ����� ���ֱ�
            return;
        }
        Weapon obj = Instantiate(Weapons[0]); // ������Ʈ Ǯ�� ���� �Ұ�
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        weaPons.Add(obj);
        LevelUPUI.SetActive(false);// ����� ���ֱ�
    }
    /// <summary>
    /// �÷��̾�� ���� �ݴϴ�.
    /// </summary>
    public void OnSwordUI()
    {
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);
            return;
        }
        Weapon obj = Instantiate(Weapons[1]); // ������Ʈ Ǯ�� ���� �Ұ�
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        weaPons.Add(obj);
        LevelUPUI.SetActive(false); // ����� ���ֱ�
    }


}
