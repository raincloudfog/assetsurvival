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
        if (ButtonManager.Instance.weaPons.Contains(Weapons.Dagger))
        {
            Debug.Log("�־� ��?");
            // �÷��̾��� ȸ�� ���� ������
            // �߻� ���� ���
            Quaternion playerRotation = CharacterManager.Instance.MainPlayer.transform.rotation ;
           
            Vector3 shootDirection = playerRotation * Vector3.forward;
            
            // �߻�ü ���� �� �߻�
            GameObject dag = Instantiate(dagger.gameObject, CharacterManager.Instance.Firepoint);
            dag.GetComponent<Dagger>().Init();
            dag.GetComponent<Dagger>().setVec(shootDirection);

            

            
        }
    }
}
