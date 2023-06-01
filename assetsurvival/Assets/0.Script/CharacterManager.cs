using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class CharacterManager : SingletonMono<CharacterManager>
{
    [SerializeField]int Weaponcount = 0; // 무기 개수 한계
    [SerializeField]Character character_type;
    [SerializeField] CameraMove maincam;
    [SerializeField]Player[] players;

    private void Awake()
    {
        Weaponcount = StartSave.Instance.WeaponCount;
        character_type = StartSave.Instance.character_type;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (character_type)
        {
            case Character.UnityChan:
                players[0].gameObject.SetActive(true);
                maincam.player = players[0].gameObject.transform;
                break;
            case Character.Misaki:
                players[1].gameObject.SetActive(true);
                maincam.player = players[1].gameObject.transform;
                break;
            case Character.Yuko:
                players[2].gameObject.SetActive(true);
                maincam.player = players[2].gameObject.transform;
                break;
            default:
                break;
        }
    }
}
