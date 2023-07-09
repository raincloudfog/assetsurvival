using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : MonoBehaviour
{
    float[] aaa = new float[]{50, 25, 20, 5};
    float[] ccc = new float[] { 50, 50 };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    List<float > checkrandom = new List<float>();
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F1))
        {
            float bbb = Choose(aaa);
            if (bbb == 1)
            {
                Debug.Log("공격");
                
            }
            else if (bbb == 0)
            {
                Debug.Log("공격 실패");
            }
            else if (bbb == 2)
            {
                Debug.Log("크리티컬");
            }
            Debug.Log("확률" + bbb);
            checkrandom.Add(bbb);
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("확률은");
            foreach (float item in checkrandom)
            {
                Debug.Log(item);
            }
            checkrandom.Clear();
           
        }
        else if(Input.GetKeyDown(KeyCode.F3))
        {
            float bbb = Choose(ccc);
            checkrandom.Add(bbb);
        }


    }

    float Choose(float[] probs)
    {
        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if(randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
