using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class StartSave : SingletonMono<StartSave>
{
    public Character character_type;
    
    private string character_name;
    public string Character_Name
    {
        get
        {
            return character_name;
        }
        set
        {
            character_name = value;
        }
    }
    private int weaponCount;
    public int WeaponCount
    {
        get
        {
            return weaponCount;
        }
        set
        {
            weaponCount = value;
        }
    }

    
    
}
