using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{

    bool isMove = true;
    bool isComeback = false;
    Vector3 pos; // 플레이어의 위치
        
    private void OnEnable()
    {
        Damage = 10 * player.damagePlus;
        WeaponSpeed = 5f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        Damage = 10 * player.damagePlus;
        WeaponSpeed = 5f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }
    private void Start()
    {
        
        Debug.Log(Damage);
    }

    public override void Attack()
    {
        if (Vector3.SqrMagnitude(transform.position - pos) < 2)
        {
            isComeback = false;
            isMove = true;
            
        }
        if (isMove == true && player.closestEnemy != null)
        {
            Vector3 rush = player.closestEnemy.position - transform.position;
            rigid.velocity = rush * WeaponSpeed; // 나중에는 콜라이더로 적 감지해서 그쪽으로 발사하기            
            StartCoroutine(Return());
        }
        else if(isComeback == true)
        {
            rigid.velocity = (pos - transform.position );           
        }
        

    }
    IEnumerator Return()
    {

        yield return new WaitForSeconds(2);
        pos = player.transform.position;
        pos.y = 0.5f;
        isComeback = true;
        isMove = false;
        yield break;
    }
}
