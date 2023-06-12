using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class CharacterManager : SingletonMono<CharacterManager>
{
    

    public int Weaponcount = 0; // 무기 개수 한계
    public Character character_type; // 캐릭터 타입
    [SerializeField] CameraMove maincam; // 카메라
    [SerializeField]Player[] players; // 캐릭터 들
    [SerializeField] WeaponRotation[] rotates; // 캐릭터안에 로테이트 스크립트
    public Player MainPlayer=null; // 메인 캐릭터
    public WeaponRotation MainPlayer_Rotate = null; // 검이 돌아갈수 있는 캐릭터 스크립트
    public Transform Firepoint = null; // 단검 나가는 방식

    private void Awake()
    {
        Weaponcount = StartSave.Instance.WeaponCount;
        character_type = StartSave.Instance.character_type;
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        int val = (int)character_type;
        players[val].gameObject.SetActive(true);
        maincam.target = players[val].gameObject.transform;
        MainPlayer = players[val];
        MainPlayer_Rotate = rotates[val];
        Firepoint = MainPlayer.FirePoint;
    }
}
