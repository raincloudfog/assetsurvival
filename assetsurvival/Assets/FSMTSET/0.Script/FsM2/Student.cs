using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Student : BaseGameEntity
{
    int knowledge; //����
    int stress; //��Ʈ����
    int fatigue; // �Ƿ�
    int totalScore; //����
    Locations currentLocation; // ���� ��ġ

    // Student�� ������ �ִ� ��� ���� , ���� ����
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
        // ��� Ŭ������ setup�޼ҵ� ȣ�� (ID , �̸� ,���� ����)
        base.SetUp(name);

        //�����Ǵ� ������Ʈ �̸� ����
        gameObject.name = $"{ID:D2}_Student_{name}";

        //student�� ���� �� �ִ� ���� ���� ��ŭ �޸� �Ҵ� , �� ���¿� Ŭ���� �޸� �Ҵ�
        states = new State[5];
        states[(int)StudentState.RestAndSleep] = new studnetOwnedStates.RestAndSleep(); // ���ӽ����̽��� �մ°���.
        // ���� ���¸� ������ ���� "RestASleep" ���·� ����
        currentState = states[(int)StudentState.RestAndSleep];

        knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocation = Locations.SweetHome;

        //PrintText("�ȳ��Ͻʴϱ�");
    }

    public override void Updated()
    {
        //PrintText("����� �Դϴ�..");
        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }
}
