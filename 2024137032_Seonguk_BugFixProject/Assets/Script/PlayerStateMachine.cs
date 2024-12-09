using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerState;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState;  //���� �÷��̾��� ���¸� ��Ÿ���� ����
    public PlayerController playerController;  //�÷��̾� ������ 

  
    void Start()
    {
        TransitionToState(new IdleState(this));  //�ʱ� ���¸� IdleState�� ���� 
    }

    void Update()
    {
        if(currentState != null)  //���� ���°� ���� �Ѵٸ� 
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()   //���� ���°� ���� �Ѵٸ� 
    {
        if (currentState != null)  
        {
            currentState.Update();
        }
    }

    //TransitionToState ���ο� ���·� ��ȯ�ϴ� �޼��� 
    public void TransitionToState(PlayerState newState)
    {
        //���� ���¿� ���ο� ���°� ���� Ÿ���� ��� ���� ��ȯ�� ���� �ʰ� �Ѵ�
        if(currentState?.GetType() == newState.GetType())
        {
            return;  //���� Ÿ���̸� ���� ��ȯ�� ���� �ʰ� ���� 
        }

        currentState?.Exit(); //���� ���°� �����Ѵٸ� [?] IF �� ó�� ���� (���� ����)
        currentState = newState;  //���ο� ���·� ��ȯ
        currentState.Enter(); //���� ����
        Debug.Log($"Transitioned to State {newState.GetType().Name}"); //���� ���� �α׷� ��� 
    }
}
