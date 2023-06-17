using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : ExpPlus
{
    public override void Init()
    {
        if (player == null)
        {
            player = CharacterManager.Instance.MainPlayer;
        }
        Exp = 50;
        Area = 3;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
