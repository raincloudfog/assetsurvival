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

    public virtual void Init()
    {
        character_type = StartSave.Instance.character_type;
        
    }

    
    public virtual void Attack()
    {
    }
    private void FixedUpdate()
    {
        Attack();
    }
}
