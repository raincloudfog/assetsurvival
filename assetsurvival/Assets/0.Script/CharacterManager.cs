using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using System;

enum hi
{
    a, b,c,d,f
}

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

    //���ϸ��鶧 ����Ҽ��� ����.06��13��
  /*  void aa()
    {

        Dictionary<hi, Action> actions = new Dictionary<hi, Action>();
        int val = UnityEngine.Random.Range(0, 5);
        actions.Add(hi.a, bb);
        actions[(hi)val]();


    }
    void bb()
    {

    }*/
}
