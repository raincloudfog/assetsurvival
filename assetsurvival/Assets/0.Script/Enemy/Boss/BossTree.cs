using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTree : BehaviorTree
{
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Animator anim;
    [SerializeField] Player PlayerTf;
    public float Hp; // 보스체력
    float Damage = 10;
    public void Init()
    {
        PlayerTf = CharacterManager.Instance.MainPlayer;
    }
    protected override void Start()
    {
        Hp = 500;
        
        base.Start();
    }

    protected override Node SetupBehaviorTree()
    {
        Node root = new SelectorNode(new List<Node>
        {
             new SequenceNode(new List<Node>{
                 new PlayerNear(transform),
                 new BossCanAttack(transform,rigid, anim,PlayerTf),
             }),
            new BossMove(Agent, PlayerTf.transform, anim)
        });

        return root;
    }

    protected override void Update()
    {
        base.Update();
    }

    public virtual void Hit(float Damage)
    {
        Hp -= Damage;
        Debug.Log(Hp + " / 데미지 입음");
        if (Hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.Clear = true;
            GameManager.Instance.Save();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Player>().Hp -= Time.deltaTime * Damage;
        }
    }
}
