using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// FSM연습용
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
                Debug.Log("플레이어가 제자리에서 대기중");
                break;
            case PlayerState.Walk:
                Debug.Log("플레이어가 걷는중");

                break;
            case PlayerState.Run:
                Debug.Log("플레이어가 뛰는중");

                break;
            case PlayerState.Attack:
                Debug.Log("플레이어가 공격중");

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
