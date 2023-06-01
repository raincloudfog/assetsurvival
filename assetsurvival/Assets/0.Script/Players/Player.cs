using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z; 
    Vector3 pos;
   


    //아이템을 밖에서 사용하기위해 퍼블릭함 get;set으로 바꿔도됨.
    public int Hp; // 체력
    public float speed; // 이동 속도
    public float delay; // 무기 딜레이
    public float damagePlus; // 무기 데미지 상승
    


    

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        pos.x = x;
        pos.z = z;

        pos.Normalize();
        transform.Translate(pos * Time.deltaTime * speed, Space.World);

        if(x < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, -90, 0), 1));
        }
        else if (x >0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 90, 0), 1));
        }
        else if (z < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 180, 0), 1 ));
        }
        else if (z > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(
                new Vector3(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), new Vector3(0, 0, 0), 1));
        }

    }
}
