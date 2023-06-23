using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{

       
    //public Transform target;       // �÷��̾��� ��ġ�� ����Ű�� Transform ������Ʈ
    public float returnSpeed = 5f; // ��ġ�� �ǵ��ƿ��� �ӵ�
    public float throwInterval = 3f; // ��ġ�� �ٽ� ������ ���ư��� ����

    //private Vector3 initialPosition; // ��ġ�� �ʱ� ��ġ
    

    [SerializeField]private bool isReturning = false;   // ��ġ�� ���ƿ��� ������ ����
    private float throwTimer = 2f;      // ��ġ ������ ������ ����ϱ� ���� Ÿ�̸�
    [SerializeField] float distanceThreshold = 1f; // ���� �Ÿ�

    private void OnEnable()
    {
        Init();
    }
    
    public override void Init()
    {
        base.Init();
        weapons = Weapons.Hammer;        
        WeaponSpeed = 5f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;             
        
    }

    private void Start()
    {
        Init();
        

    }
    private void FixedUpdate()
    {
        
        Attack();
    }
   

    public override void Attack()
    {

        float distance = Vector3.SqrMagnitude(player.transform.position - transform.position);

        // ���� �������� ��ġ�� �ٽ� ������
        throwTimer += Time.deltaTime;

        if (isReturning == true)
        {
            if (distance < distanceThreshold)
            {
                // ���߰ų� �ʿ��� ���� ����
                isReturning = false;
                throwTimer = 0f;
                rigid.velocity = Vector3.zero;
            }

            // �÷��̾� �������� ���� �ӵ��� �̵�
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rigid.velocity = direction * WeaponSpeed;
        }
        else if(throwTimer >= throwInterval && !isReturning)
        {
            ThrowHammer();
        }
          
        
    }

    private void ThrowHammer()
    {
        // ��ġ�� ���� (������ ���ư��� ���� ����)
        // ��ġ�� ���� �� Collider �Ǵ� Trigger�� �̿��� ������ �浹 ����

        // ��ġ�� ������ �� ���� ����
        isReturning = true;
        
        if(player.closestEnemy != null)
            rigid.velocity = (player.closestEnemy.position - transform.position) * 1f;
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
