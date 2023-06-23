using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z; 
    Vector3 pos;
    List<Weapon> Weapons = new List<Weapon>();
    

    //�������� �ۿ��� ����ϱ����� �ۺ��� get;set���� �ٲ㵵��.
    public float Hp; // ü��
    public int MaxHP;//�ִ� ü��
    public float speed; // �̵� �ӵ�
    public float delay; // ���� ������
    public float damagePlus; // ���� ������ ���
    public float CriticalChance; // ũ��Ƽ�� ����
    public float CriticalPlus; //ũ�� ������ ����
    public Collider[] Enemys; // ����
    public Transform closestEnemy = null;  // ���� ����� ���� Transform�� ������ ����
    public float detectionRadius = 10f;  // Ž�� �ݰ�
    public Transform FirePoint = null;
    public Animator anim; // �ִϸ�����

    public virtual void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();        
        FindClosestEnemy();
        AA();
    }

    

    private void FindClosestEnemy()
    {
        // �÷��̾� �ֺ��� Collider �迭�� ������
        Enemys = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Enemy"));

        float closestDistance = Mathf.Infinity;  // ���� ����� ������ �Ÿ��� ������ ����
        

        foreach (Collider collider in Enemys)
        {
            // �÷��̾�� �� ������ �Ÿ��� ���
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            // ���� ������ �Ÿ��� ���� ����� �Ÿ����� ������
            if (distance < closestDistance)
            {
                closestDistance = distance;  // ���� ����� �Ÿ��� ����
                closestEnemy = collider.transform;  // ���� ����� ���� ����
                closestEnemy.position = new Vector3(closestEnemy.position.x, 0.5f, closestEnemy.position.z);
            }
        }        
    }

    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        anim.SetFloat("x", x);
        anim.SetFloat("z", z);
        pos.x = x;
        pos.z = z;

        pos.Normalize();
        
        if(x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation, Quaternion.LookRotation(pos), 0.15f
                );
            transform.Translate(pos * Time.deltaTime * speed, Space.World);
        }
        

        

    }
    
    void plusWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }

    void AA() // �׽�Ʈ��
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Rank.Instance.HighScore += 10;
        }
    }

    public virtual void HIt(float hitdamage)
    {
        Hp -= hitdamage;
        if(Hp <= 0)
        {
            Debug.Log("�׾����ϴ�.");
        }
    }



}
