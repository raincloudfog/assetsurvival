using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Student : BaseGameEntity
{
    int knowledge; //지식
    int stress; //스트레스
    int fatigue; // 피로
    int totalScore; //점수
    Locations currentLocation; // 현재 위치

    // Student가 가지고 있는 모든 상태 , 현재 상태
    State[] states;
    State currentState;

    public int Knowledge
    {
        get
        {
            return knowledge;
        }
        set
        {
            knowledge = Mathf.Max(0, value);
        }
    }
    public int Stress
    {
        get
        {
            return stress;
        }
        set
        {
            stress = Mathf.Max(0, value);
        }
    }
    public int Fatigue
    {
        get
        {
            return fatigue;
        }
        set
        {
            fatigue = Mathf.Max(0, value);
        }
    }
    public int TotalScore
    {
        get
        {
            return totalScore;
        }
        set
        {
            totalScore = Mathf.Clamp(0, value, 100);
        }
    }

    public Locations CurrentLocation
    {
        get
        {
            return currentLocation;
        }
        set
        {
            currentLocation = value;
        }
    }

    public override void SetUp(string name)
    {
        // 기반 클래스의 setup메소드 호출 (ID , 이름 ,색상 설정)
        base.SetUp(name);

        //생성되는 오브젝트 이름 설정
        gameObject.name = $"{ID:D2}_Student_{name}";

        //student가 가질 수 있는 상태 개수 만큼 메모리 할당 , 각 상태에 클래스 메모리 할당
        states = new State[5];
        states[(int)StudentState.RestAndSleep] = new studnetOwnedStates.RestAndSleep(); // 네임스페이스에 잇는거임.
        // 현재 상태를 집에서 쉬는 "RestASleep" 상태로 설정
        currentState = states[(int)StudentState.RestAndSleep];

        knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocation = Locations.SweetHome;

        //PrintText("안녕하십니까");
    }

    public override void Updated()
    {
        //PrintText("대기중 입니다..");
        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }
}
