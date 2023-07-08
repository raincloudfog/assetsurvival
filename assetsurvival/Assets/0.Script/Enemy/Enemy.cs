using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
    
    protected Attributes.Monster data;
    [SerializeField]
    protected ExpPlus[] Exps;
    protected Expitem _ExpItem;
    protected int rand = 0;
    [SerializeField] Material material;
    [SerializeField] Material[] GetMaterials;
    [SerializeField]SpriteRenderer spr;

    public float Hp; // 적체력
    public float maxHP; // 적 최대 체력
    public float moveSpeed; // 이동속도
    public float Damage; // 적 공격력
    public Player player;
    [SerializeField] protected NavMeshAgent Agent;

    
    /// <summary>
    /// 소환 될때 세팅될 값
    /// </summary>
    /// <param name="data"></param>
    /// <param name="player"></param>
    public virtual void SetData(Attributes.Monster data, Player player)
    {
        
    }


    
    void Update()
    {
        Agent.SetDestination(player.transform.position);   
    }
    /// <summary>
    /// 좀비 때리는 함수
    /// </summary>
    /// <param name="Damage"></param>
    public virtual void Hit(float Damage)
    {
        Hp -= Damage;
        
        if(Hp <= 0)
        {
            rand = Random.Range(1, 3);
            ExpPlus obj = Instantiate(Exps[rand], transform);
            obj.transform.SetParent(null);
            obj.Init();
            GameManager.Instance.ZombieKillCount++;
            ObjectPool.Instance.ZombieReturn(this. gameObject);
        }
    }

    

}
