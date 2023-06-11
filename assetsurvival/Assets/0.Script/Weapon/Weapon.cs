using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage; // ������ �÷������� ������ ���� �ۼ�Ʈ�� �־ �Ҽ����� ����Ϸ���.
    public float WeaponSpeed; // ���� �ӵ� 
    public float Delay; // ������ ������
    public float critPower; // ġ��Ÿ ���� ������
    public float critpersent; // ġ��Ÿ Ȯ��
    public Player player; // �÷��̾� ��ġ
    [SerializeField] protected Rigidbody rigid;
    public Character character_type; // ĳ���Ͱ� �������� Ȯ���ϱ�����.
    public Transform firePoint; // �߻� ����

    public virtual void Init()
    {
        switch (CharacterManager.Instance.character_type)
        {
            case Character.UnityChan:
                player = FindObjectOfType<UnityChan>();
                firePoint = player.GetComponentInChildren<Firepos>().transform;
                break;
            case Character.Misaki:
                player = FindObjectOfType<Misaki>();
                firePoint = player.GetComponentInChildren<Firepos>().transform;
                break;
            case Character.Yuko:
                player = FindObjectOfType<Yuko>();
                firePoint = player.GetComponentInChildren<Firepos>().transform;
                break;
            default:
                break;
        }
        character_type = StartSave.Instance.character_type;
        
    }

    
    public virtual void Attack()
    {
    }
    public virtual void Attack(Vector3 shootDirection)
    {

        rigid.velocity = shootDirection * 5;
    }
    
}
