using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : ExpPlus
{
    public override void Init()
    {
        if (player == null)
        {
            player = CharacterManager.Instance.MainPlayer;
        }
        Exp = 30;
        Area = 3;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
