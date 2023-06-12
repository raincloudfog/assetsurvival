using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
   
    protected Attributes.Monster data;
    


    public float Hp; // ��ü��
    public float maxHP; // �� �ִ� ü��
    public float moveSpeed; // �̵��ӵ�
    public float Damage; // �� ���ݷ�
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
