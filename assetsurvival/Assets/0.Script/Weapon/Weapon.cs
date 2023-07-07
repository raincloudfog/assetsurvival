using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Weapons weapons = Weapons.End;


    public float Damage; // ������ �÷������� ������ ���� �ۼ�Ʈ�� �־ �Ҽ����� ����Ϸ���.
    public float WeaponSpeed; // ���� �ӵ� 
    public float Delay; // ������ ������
    public float DamageUp;
    public float critPower; // ġ��Ÿ ���� ������
    public float critpersent; // ġ��Ÿ Ȯ��
    public Player player; // �÷��̾� ��ġ
    [SerializeField] protected Rigidbody rigid;
    public Character character_type; // ĳ���Ͱ� �������� Ȯ���ϱ�����.
    public Transform firePoint; // �߻� ����

    /// <summary>
    /// �÷��̾ ã���ְ� ĳ���� Ÿ���� ã����.
    /// </summary>
    public virtual void Init() 
    {
        character_type = StartSave.Instance.character_type;
        player = CharacterManager.Instance.MainPlayer;
        firePoint = player.FirePoint;



    }
    public virtual void PowerUp(int DamageUp)
    {

    }



    public virtual void Attack()
    {
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (other.GetComponent<ZombieHIt>() == true)
            {
                ZombieHIt enemy = other.GetComponent<ZombieHIt>();
                enemy.zombieHit(WeaponManager.Instance.Hammerdamage);
            }
            else if (other.GetComponent<BossTree>() == true)
            {
                BossTree boss = other.GetComponent<BossTree>();
                boss.Hit(WeaponManager.Instance.Hammerdamage);
            }

        }
    }

}
