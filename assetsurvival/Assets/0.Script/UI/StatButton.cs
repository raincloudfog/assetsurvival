using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    public stat _stat; // ��ư�� �ٲ��ֱ����� enum
    public Image _img; // �̹���
    public Text _StatName; // ���� �̸�
    public Text _Stattxt; // ���� ������

    public void Init(StatPlus statPlus)
    {
        _stat = statPlus._stat;
       _img = statPlus._img;
        _StatName.text = statPlus._StatName;
        _Stattxt.text = statPlus._Stattxt;
    }
}
