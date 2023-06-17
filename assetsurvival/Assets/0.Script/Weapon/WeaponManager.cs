using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class WeaponManager : SingletonMono<WeaponManager>
{
    public Player player;
    public Weapon[] Weapons;
    public List<Weapon> weaPons = new List<Weapon>();

    public float Daggerdamage; // 단검들 데미지
    public float Hammerdamage;
    public float Sworddamage; 
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = CharacterManager.Instance.MainPlayer;
        player.Init();
        Daggerdamage =  60 *player.damagePlus; // 단검데미지 설정
        Hammerdamage = 10 * player.damagePlus;//해머 데미지 설정
        Sworddamage = 10 * player.damagePlus;
        
        //Debug.Log(player.name);
        //Debug.Log(player.damagePlus);
        Debug.Log(Daggerdamage);
        weaPons = new List<Weapon>(/*StartSave.Instance.WeaponCount - 1*/);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log(weaPons.Count);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (CharacterManager.Instance.Weaponcount == weaPons.Count)
            {
                Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
                return;
            }
            GameManager.Instance.SetExp(100);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterManager.Instance.Weaponcount == weaPons.Count)
            {
                Debug.Log("무기횟수가 한계치에 도달 했습니다."); // 무기 한계치에 도달했으니 더이상 생성 불가능.
                return;
            }
            Weapon obj = Instantiate(Weapons[1]); // 오브젝트 풀링 수정 할것
            obj.transform.position = player.transform.position + new Vector3(0, 0, 2);
            obj.transform.SetParent(null);
            weaPons.Add(obj);

        }
    }

    public void DaggerPowerUp(int DamageUp)
    {
         
        Daggerdamage += DamageUp;
    }
    public void HammerPowerUp(int DamageUp)
    {

        Hammerdamage += DamageUp;
    }
    public void SwordPowerUp(int DamageUp)
    {

        Sworddamage += DamageUp;
    }
}
