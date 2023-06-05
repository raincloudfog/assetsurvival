using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage; // 데미지 플롯이유는 데미지 증가 퍼센트가 있어서 소수점도 허용하려함.
    public float WeaponSpeed; // 공격 속도 
    public float Delay; // 무기의 딜레이
    public float critPower; // 치명타 증가 데미지
    public float critpersent; // 치명타 확률
    public Player player; // 플레이어 위치
    [SerializeField] protected Rigidbody rigid;
    public Character character_type; // 캐릭터가 무엇인지 확인하기위함.

    public virtual void Init()
    {
        character_type = StartSave.Instance.character_type;
        
    }

    
    public virtual void Attack()
    {
    }
    private void FixedUpdate()
    {
        Attack();
    }
}
