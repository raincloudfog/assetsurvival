using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class WeaponManager : SingletonMono<WeaponManager>
{
    public Player player;
    public Weapon[] Weapons;
    public List<Weapon> weaPons = new List<Weapon>(); 
    // Start is called before the first frame update
    void Start()
    {
        weaPons = new List<Weapon>(/*StartSave.Instance.WeaponCount - 1*/);
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log(weaPons.Count);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (CharacterManager.Instance.Weaponcount == weaPons.Count)
            {
                Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
                return;
            }
            GameManager.Instance.Exp += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterManager.Instance.Weaponcount == weaPons.Count)
            {
                Debug.Log("����Ƚ���� �Ѱ�ġ�� ���� �߽��ϴ�."); // ���� �Ѱ�ġ�� ���������� ���̻� ���� �Ұ���.
                return;
            }
            Weapon obj = Instantiate(Weapons[1]); // ������Ʈ Ǯ�� ���� �Ұ�
            obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
            obj.transform.SetParent(null);
            weaPons.Add(obj);

        }
    }
}
