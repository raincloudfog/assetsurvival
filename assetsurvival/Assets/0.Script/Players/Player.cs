using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z; 
    Vector3 pos;
    List<Weapon> Weapons = new List<Weapon>();
    

    //아이템을 밖에서 사용하기위해 퍼블릭함 get;set으로 바꿔도됨.
    public float Hp; // 체력
    public int MaxHP;//최대 체력
    public float speed; // 이동 속도
    public float delay; // 무기 딜레이
    public float damagePlus; // 무기 데미지 상승
    public float CriticalChance; // 크리티컬 찬스
    public float CriticalPlus; //크리 데미지 증가
    public Collider[] Enemys; // 적들
    public Transform closestEnemy = null;  // 가장 가까운 적의 Transform을 저장할 변수
    public float detectionRadius = 10f;  // 탐지 반경
    public Transform FirePoint = null;
    public Animator anim; // 애니메이터
    public Vector3 minPosition; // 허용되는 최소 위치
    public Vector3 maxPosition; // 허용되는 최대 위치
    public GameObject planeObject; // Plane 오브젝트를 참조하는 변수
    public void OnEnable()
    {
        // Plane의 스케일 값을 기반으로 min과 max 범위를 설정
        
        Renderer planeRenderer = planeObject.GetComponent<Renderer>();
        Vector3 planeSize = planeRenderer.bounds.size;

        minPosition = -planeSize * 0.5f;
        maxPosition = planeSize * 0.5f;

    }

    public virtual void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();        
        FindClosestEnemy();
        //AA();
        Dead();
    }

    

    private void FindClosestEnemy()
    {
        // 플레이어 주변의 Collider 배열을 가져옴
        Enemys = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Enemy"));

        float closestDistance = Mathf.Infinity;  // 가장 가까운 적과의 거리를 저장할 변수
        

        foreach (Collider collider in Enemys)
        {
            // 플레이어와 적 사이의 거리를 계산
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            // 현재 적과의 거리가 가장 가까운 거리보다 작으면
            if (distance < closestDistance)
            {
                closestDistance = distance;  // 가장 가까운 거리를 갱신
                closestEnemy = collider.transform;  // 가장 가까운 적을 갱신
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

        if (x != 0 || z != 0)
        {
            // 플레이어의 이동
            Vector3 newPos = transform.position + pos * speed * Time.deltaTime;
            newPos.x = Mathf.Clamp(newPos.x, minPosition.x, maxPosition.x);
            newPos.z = Mathf.Clamp(newPos.z, minPosition.z, maxPosition.z);
            transform.position = newPos;

            // 플레이어의 회전
            Quaternion targetRotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        }




    }
    
    void plusWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }

    void AA() // 테스트용
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Rank.Instance.HighScore += 10;
        }
    }

    public virtual void Dead()
    {
        if(Hp <= 0)
        {
            
            Debug.Log("죽었습니다.");
            GameManager.Instance.Save();
        }
    }



}
