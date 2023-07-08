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

    public float Hp; // ��ü��
    public float maxHP; // �� �ִ� ü��
    public float moveSpeed; // �̵��ӵ�
    public float Damage; // �� ���ݷ�
    public Player player;
    [SerializeField] protected NavMeshAgent Agent;

    
    /// <summary>
    /// ��ȯ �ɶ� ���õ� ��
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
    /// ���� ������ �Լ�
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
