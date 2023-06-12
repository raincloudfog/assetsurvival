using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{

    public Transform rotateObj; // �ֺ��� ������ ��ü
    Vector3 vec = Vector3.zero;
    float x, z = 0; // �ӽ� ����

    float radius = 3; // ���� ������
    float degree = 0; //  ȸ���� ����
    float rad = 0;// ���� ���
    float speed = 20; // ȸ�� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackMove();
    }

    public void AttackMove()
    {
        if (rotateObj != null)
        {

            degree += Time.deltaTime * speed; // �����Ӵ� �ӵ� * �ð�
            if (degree < 360)
            {
                rad = Mathf.Deg2Rad * degree; // sin cos�� ���� �����̱� ������ �Ϲ� ���� ���� �������� �ٲ� ���� �ʿ���
                x = radius * Mathf.Sin(rad);
                z = radius * Mathf.Cos(rad);
                vec.x = x;
                vec.z = z;
                rotateObj.transform.position = transform.position + vec; // �ְ� �Ǵ� ���� ��ġ(�÷��̾�) + �ְ��Ǵ� ���� ��ġ�κ��� ������ ��ŭ �������ְ�
                                                                         // �� ���� ��ġ�� �ش�Ǵ� ������ ��� ������Ʈ ����
                rotateObj.transform.rotation = Quaternion.Euler(90, degree, 0); // ������ ���ؼ� x�� 90�� ������,
                                                                                // ���� �ִ� �����̱� ������ y���� degree��ŭ ������.
            }
            else
            {
                degree = 0;//360�� �̻��� �ȴٸ� 0���� �ʱ�ȭ ����
            }

        }
    }
}
