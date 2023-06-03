using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z; 
    Vector3 pos;
    List<Weapon> Weapons = new List<Weapon>();
    

    //�������� �ۿ��� ����ϱ����� �ۺ����� get;set���� �ٲ㵵��.
    public int Hp; // ü��
    public float speed; // �̵� �ӵ�
    public float delay; // ���� ������
    public float damagePlus; // ���� ������ ���
    public Collider[] Enemys; // ����
    public Transform closestEnemy = null;  // ���� ����� ���� Transform�� ������ ����
    public float detectionRadius = 10f;  // Ž�� �ݰ�

    // Update is called once per frame
    void Update()
    {
        Move();        
        FindClosestEnemy();
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

        pos.x = x;
        pos.z = z;

        pos.Normalize();
        transform.Translate(pos * Time.deltaTime * speed, Space.World);

        if(x < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, -90, 0), 1));
        }
        else if (x >0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 90, 0), 1));
        }
        else if (z < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 180, 0), 1 ));
        }
        else if (z > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 0, 0), 1));
        }

    }
    
    void plusWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }
}