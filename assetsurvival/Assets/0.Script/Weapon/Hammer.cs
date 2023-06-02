using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    bool isMove = true;
    bool isComeback = false;
    Vector3 pos; // 움직임
    // Start is called before the first frame update
    private void OnEnable()
    {
        Damage = 10;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Damage = 10;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }

    public override void Attack()
    {
        if (Vector3.SqrMagnitude(transform.position - pos) < 2)
        {
            isComeback = false;
            isMove = true;
            
        }
        if (isMove == true)
        {
            rigid.velocity = Vector3.forward * WeaponSpeed; // 나중에는 콜라이더로 적 감지해서 그쪽으로 발사하기
            
            
            //isComeback = true;
            StartCoroutine(Return());
        }
        else if(isComeback == true)
        {
            pos = player.position;
            pos.y = 1f;
            rigid.velocity = (pos - transform.position );
            //transform.Translate(Vector3.back * WeaponSpeed, Space.World);
            
        }
        

    }
    IEnumerator Return()
    {

        yield return new WaitForSeconds(2);
        isComeback = true;
        isMove = false;
        yield break;
    }
}
