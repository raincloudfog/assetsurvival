using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    public stat _stat; // 버튼을 바꿔주기위한 enum
    public Image _img; // 이미지
    public Text _StatName; // 스탯 이름
    public Text _Stattxt; // 스탯 증가폭

    public void Init(StatPlus statPlus)
    {
        _stat = statPlus._stat;
       _img = statPlus._img;
        _StatName.text = statPlus._StatName;
        _Stattxt.text = statPlus._Stattxt;
    }
}
