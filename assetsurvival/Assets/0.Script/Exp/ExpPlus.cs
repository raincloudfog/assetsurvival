using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExpPlus : MonoBehaviour
{
    protected int Exp;
    protected Player player;
    protected int Area;

    public abstract void Init();
    public virtual void Move()
    {
        Vector3 player_pos = player.transform.position - transform.position;
        if (Vector3.SqrMagnitude(player_pos) < Area)
        {
            transform.Translate(player_pos * 10f * Time.deltaTime, Space.World);
            if (Vector3.SqrMagnitude(player_pos) <= 0.5f)
            {
                GameManager.Instance.SetExp(Exp);
                Destroy(gameObject);
            }
        }
    }
}
