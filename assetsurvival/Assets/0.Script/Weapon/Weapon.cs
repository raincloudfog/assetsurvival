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
    public Transform player; // �÷��̾� ��ġ
    protected Rigidbody rigid;
    public virtual void Attack()
    {
    }
    private void FixedUpdate()
    {
        Attack();
    }
}
