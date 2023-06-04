using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    
    [SerializeField] float radius = 1f;
    [SerializeField] float angle = 0f;
    Vector3 startpos = new Vector3(0,-45, 0);
    Vector3 Endpos = new Vector3(0, 45, 0);
    Vector3 pos = Vector3.zero;
    private void OnEnable()
    {
        Damage = 10 * player.damagePlus;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.3f;
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        Damage = 10 * player.damagePlus;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }
    

    public override void Attack()
    {
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.rotation = Quaternion.Euler(Vector3.Lerp(startpos, Endpos, 5f));
        transform.position = new Vector3(player.transform.position.x+x, 0, player.transform.position.z+y);

        angle += WeaponSpeed * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(0,0 , 2f);
        //transform.Rotate(Vector3.forward, WeaponSpeed * Delay);
    }
}
