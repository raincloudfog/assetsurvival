using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
   
    protected Attributes.Monster data;
    


    public float Hp; // 적체력
    public float maxHP; // 적 최대 체력
    public float moveSpeed; // 이동속도
    public float Damage; // 적 공격력
    public Player player;
    [SerializeField] protected NavMeshAgent Agent;
    // Start is called before the first frame update
    public virtual void SetData(Attributes.Monster data, Player player)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(player.transform.position);   
    }
}
