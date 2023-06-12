using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class CharacterManager : SingletonMono<CharacterManager>
{
    

    public int Weaponcount = 0; // ���� ���� �Ѱ�
    public Character character_type; // ĳ���� Ÿ��
    [SerializeField] CameraMove maincam; // ī�޶�
    [SerializeField]Player[] players; // ĳ���� ��
    [SerializeField] WeaponRotation[] rotates; // ĳ���;ȿ� ������Ʈ ��ũ��Ʈ
    public Player MainPlayer=null; // ���� ĳ����
    public WeaponRotation MainPlayer_Rotate = null; // ���� ���ư��� �ִ� ĳ���� ��ũ��Ʈ
    public Transform Firepoint = null; // �ܰ� ������ ���

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
