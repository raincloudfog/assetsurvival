using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{

       
    //public Transform target;       // 플레이어의 위치를 가리키는 Transform 컴포넌트
    public float returnSpeed = 5f; // 망치의 되돌아오는 속도
    public float throwInterval = 3f; // 망치가 다시 적에게 날아가는 간격

    //private Vector3 initialPosition; // 망치의 초기 위치
    

    [SerializeField]private bool isReturning = false;   // 망치가 돌아오는 중인지 여부
    private float throwTimer = 2f;      // 망치 던지기 간격을 계산하기 위한 타이머
    [SerializeField] float distanceThreshold = 1f; // 일정 거리

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

        // 일정 간격으로 망치를 다시 던지기
        throwTimer += Time.deltaTime;

        if (isReturning == true)
        {
            if (distance < distanceThreshold)
            {
                // 멈추거나 필요한 동작 수행
                isReturning = false;
                throwTimer = 0f;
                rigid.velocity = Vector3.zero;
            }

            // 플레이어 방향으로 일정 속도로 이동
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
        // 망치를 던짐 (적에게 날아가는 동작 구현)
        // 망치를 던진 후 Collider 또는 Trigger를 이용해 적과의 충돌 감지

        // 망치가 던져진 후 상태 설정
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
