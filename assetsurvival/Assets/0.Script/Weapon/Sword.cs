using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    
    [SerializeField] float radius = 1f;
    [SerializeField] float angle = 0f;

    Vector3 pos = Vector3.zero;
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
        Damage = 10;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }
    
    public override void Attack()
    {
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(player.position.x+x, 0, player.position.z+y);

        angle += WeaponSpeed * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(90, x, 0);
        transform.Rotate(Vector3.forward, WeaponSpeed * Delay);
    }
}
