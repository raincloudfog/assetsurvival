using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float Hp; // 적체력
    public float moveSpeed; // 이동속도
    public float Demage; // 적 공격력
    Player player;
    [SerializeField] NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(player.transform.position);   
    }
}
