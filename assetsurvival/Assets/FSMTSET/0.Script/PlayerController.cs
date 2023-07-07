using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// FSM������
/// </summary>
public class PlayerController : MonoBehaviour
{
    PlayerState playerState;

    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeState(PlayerState.Idle);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeState(PlayerState.Walk);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeState(PlayerState.Run);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeState(PlayerState.Attack);

        UpdateState();
    }

    void UpdateState()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                Debug.Log("�÷��̾ ���ڸ����� �����");
                break;
            case PlayerState.Walk:
                Debug.Log("�÷��̾ �ȴ���");

                break;
            case PlayerState.Run:
                Debug.Log("�÷��̾ �ٴ���");

                break;
            case PlayerState.Attack:
                Debug.Log("�÷��̾ ������");

                break;
            default:
                break;
        }
    }

    public void ChangeState(PlayerState  playerState)
    {
        this.playerState = playerState;
    }
}
