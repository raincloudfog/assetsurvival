using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{

    bool isMove = true;
    bool isComeback = false;
    Vector3 pos; // �÷��̾��� ��ġ
        
    private void OnEnable()
    {
        Init();
    }
    
    public override void Init()
    {
        base.Init();
        weapons = Weapons.Hammer;

        Damage = 10 * player.damagePlus;
        WeaponSpeed = 5f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }

    private void Start()
    {
        Init();
        Debug.Log(Damage);
    }
    private void FixedUpdate()
    {
        Attack();
    }

    /// <summary>
    /// �ظ��� ���� ����Դϴ�.
    /// </summary>
    public override void Attack()
    {
        if (Vector3.SqrMagnitude(transform.position - pos) <= 2)
        {
            
            isComeback = false;
            isMove = true;
            rigid.velocity = Vector3.zero;

        }
        if (isMove == true && player.closestEnemy != null)
        {
            Vector3 rush = player.closestEnemy.position - transform.position;
            rigid.velocity = rush * WeaponSpeed; // ���߿��� �ݶ��̴��� �� �����ؼ� �������� �߻��ϱ�            
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
