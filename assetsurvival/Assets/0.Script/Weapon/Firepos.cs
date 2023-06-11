using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepos : MonoBehaviour
{
    public Dagger dagger; // �ܰ� ������ Ȯ�ο�
    public Weapon[] weapons; // �����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.Instance.weaPons.Contains(new Dagger()))
        {
            Debug.Log("�־� ��?");
            // �÷��̾��� ȸ�� ���� ������
            Quaternion playerRotation = dagger.player.transform.rotation;

            // �߻� ���� ���
            Vector3 shootDirection = playerRotation * Vector3.forward;

            // �߻�ü ���� �� �߻�
            GameObject dag = Instantiate(dagger.gameObject, dagger.firePoint.position, playerRotation);
            dag.GetComponent<Dagger>().setVec(shootDirection);
        }
    }
}
