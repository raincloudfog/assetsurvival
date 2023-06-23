using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    [SerializeField]bool go;

    
    [SerializeField] GameObject Hammer; // ÇØ¸Ó
   
    

    Vector3 locationInFrontOfPlayer;

    // Start is called before the first frame update
    
    
    void Start()
    {
        
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }

    private void OnEnable()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public override void Init()
    {
        base.Init();
        weapons = Weapons.Hammer;
        WeaponSpeed = 5f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
        go = false;
        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z)
                                    + player.transform.forward * 10f;

        
        StartCoroutine(Boom());
    }

    public override void Attack()
    {
        transform.Rotate(Time.deltaTime * 500, 0, 0);

        if (go == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40f);

        }
        if (go == false)
        {
            /*transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, transform.position.z)
                , Time.deltaTime * 40f);
*/
            rigid.velocity = (player.transform.position - transform.position) * WeaponSpeed;
        }
        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
        {
            
            ObjectPool.Instance.HammerReturn(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            ZombieHIt enemy = other.GetComponent<ZombieHIt>();
            enemy.zombieHit(WeaponManager.Instance.Hammerdamage);
        }
    }
}
