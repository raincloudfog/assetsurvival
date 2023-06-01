using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z; 
    Vector3 pos;
   


    //�������� �ۿ��� ����ϱ����� �ۺ��� get;set���� �ٲ㵵��.
    public int Hp; // ü��
    public float speed; // �̵� �ӵ�
    public float delay; // ���� ������
    public float damagePlus; // ���� ������ ���
    


    

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
