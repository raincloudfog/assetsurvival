using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float Hp; // ��ü��
    public float moveSpeed; // �̵��ӵ�
    public float Demage; // �� ���ݷ�
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
