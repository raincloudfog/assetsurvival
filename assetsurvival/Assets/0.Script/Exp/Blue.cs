using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : ExpPlus
{
    public override void Init()
    {
        if(player == null)
        {
            player = CharacterManager.Instance.MainPlayer;
        }
        Exp = 10;
        Area = 3;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
