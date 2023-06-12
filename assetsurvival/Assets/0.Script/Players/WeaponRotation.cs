using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{

    public Transform rotateObj; // 주변을 돌게할 물체
    Vector3 vec = Vector3.zero;
    float x, z = 0; // 임시 변수

    float radius = 3; // 도는 반지름
    float degree = 0; //  회전할 각도
    float rad = 0;// 각도 계산
    float speed = 20; // 회전 속도

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

            degree += Time.deltaTime * speed; // 프레임당 속도 * 시간
            if (degree < 360)
            {
                rad = Mathf.Deg2Rad * degree; // sin cos는 라디안 단위이기 때문에 일반 각도 에서 라디안으로 바꾼 값이 필요함
                x = radius * Mathf.Sin(rad);
                z = radius * Mathf.Cos(rad);
                vec.x = x;
                vec.z = z;
                rotateObj.transform.position = transform.position + vec; // 주가 되는 것의 위치(플레이어) + 주가되는 것의 위치로부터 반지름 만큼 떨어져있고
                                                                         // 원 위의 위치에 해당되는 값으로 계속 업데이트 해줌
                rotateObj.transform.rotation = Quaternion.Euler(90, degree, 0); // 눕히기 위해서 x로 90도 돌리고,
                                                                                // 누워 있는 상태이기 때문에 y값을 degree만큼 돌려줌.
            }
            else
            {
                degree = 0;//360도 이상이 된다면 0도로 초기화 해줌
            }

        }
    }
}
