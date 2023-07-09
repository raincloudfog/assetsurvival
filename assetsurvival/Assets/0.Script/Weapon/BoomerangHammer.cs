using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangHammer : Weapon
{
    [SerializeField]bool go;

    
    [SerializeField] GameObject Hammer; // 해머
   
    

    Vector3 locationInFrontOfPlayer;

    // Start is called before the first frame update
    float[] Crichance = new float[] { 50, 50 };
    
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

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            float Cri = Choose(Crichance);
            if (other.GetComponent<ZombieHIt>() == true)
            {
                ZombieHIt enemy = other.GetComponent<ZombieHIt>();
                if(Cri == 0)
                {
                    normaldamagetxt();
                    enemy.zombieHit(WeaponManager.Instance.Hammerdamage * player.damagePlus);
                }
                else if(Cri == 1)
                {
                    Cridamagetxt();
                    enemy.zombieHit(WeaponManager.Instance.Hammerdamage *
                        (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Hammer 크리티컬!!");
                }

            }
            else if (other.GetComponent<BossTree>() == true)
            {
                BossTree boss = other.GetComponent<BossTree>();
                if(Cri == 0)
                {
                    normaldamagetxt();
                    boss.Hit(WeaponManager.Instance.Hammerdamage * player.damagePlus);
                }
                else if( Cri == 1)
                {
                    Cridamagetxt();
                    boss.Hit(WeaponManager.Instance.Hammerdamage *
                        (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Hammer 크리티컬!!");
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        attacktxt.gameObject.SetActive(false);
    }
    protected override float Choose(float[] probs)
    {
        float total = 0;
        foreach (float item in probs)
        {
            total += item;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    void normaldamagetxt()
    {
        DamageTxtScript obj = ObjectPool.Instance.txtDequeue();
        obj.transform.position = transform.position;
        obj.transform.SetParent(null);
        obj.txt.text = (WeaponManager.Instance.Hammerdamage * (player.damagePlus)).ToString();
    }

    void Cridamagetxt()
    {
        DamageTxtScript obj = ObjectPool.Instance.txtDequeue();
        obj.transform.position = transform.position;
        obj.transform.SetParent(null);
        obj.txt.text = (WeaponManager.Instance.Hammerdamage * (critPower + player.CriticalPlus + player.damagePlus)).ToString();
    }
}
