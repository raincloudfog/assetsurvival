using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTxtScript : MonoBehaviour
{
    public TMP_Text txt;
    float timer;

    private void OnDisable()
    {
        txt.text = null;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            timer = 0;
            ObjectPool.Instance.txtEnqueue(this);
        }
    }
}
