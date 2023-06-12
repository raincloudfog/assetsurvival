using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;




public class ButtonManager : SingletonMono<ButtonManager>
{
    
    List<Button> Waepon_Buttons = new List<Button>();
    public List<Weapons> weaPons = new List<Weapons>();

    public Weapon[] Weapons; // ���� ����
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
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);// ����� ���ֱ�
            return;
        }
        Weapon obj = Instantiate(Weapons[0]); // ������Ʈ Ǯ�� ���� �Ұ�
        obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
        obj.transform.SetParent(null);
        obj.Init();
        weaPons.Add(obj.weapons);
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
        obj.Init();
        weaPons.Add(obj.weapons);
        CharacterManager.Instance.MainPlayer_Rotate.rotateObj = obj.transform;
        LevelUPUI.SetActive(false); // ����� ���ֱ�
    }

    /// <summary>
    /// firepos�� �ܰ��� �ݴϴ�.
    /// </summary>
    public void OnDaggerUI()
    {
        if (CharacterManager.Instance.Weaponcount == weaPons.Count)
        {
            Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
            LevelUPUI.SetActive(false);// ����� ���ֱ�
            return;
        }

        Weapon obj = Instantiate(Weapons[2]); // ������Ʈ Ǯ�� �����Ұ�
        obj.Init();
        weaPons.Add(obj.weapons);
        obj.gameObject.SetActive(false);

        LevelUPUI.SetActive(false); // ����� ���ֱ�
    }

}
