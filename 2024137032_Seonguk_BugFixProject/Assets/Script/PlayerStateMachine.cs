using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerState;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState;  //현재 플레이어의 상태를 나타내는 변수
    public PlayerController playerController;  //플레이어 참조용 

  
    void Start()
    {
        TransitionToState(new IdleState(this));  //초기 상태를 IdleState로 설정 
    }

    void Update()
    {
        if(currentState != null)  //현재 상태가 존재 한다면 
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()   //현재 상태가 존재 한다면 
    {
        if (currentState != null)  
        {
            currentState.Update();
        }
    }

    //TransitionToState 새로운 상태로 전환하는 메서드 
    public void TransitionToState(PlayerState newState)
    {
        //현재 상태와 새로운 상태가 같은 타입일 경우 상태 전환을 하지 않게 한다
        if(currentState?.GetType() == newState.GetType())
        {
            return;  //같은 타입이면 상태 전환을 하지 않고 리턴 
        }

        currentState?.Exit(); //현재 상태가 존재한다면 [?] IF 문 처럼 쓰임 (상태 종료)
        currentState = newState;  //새로운 상태로 전환
        currentState.Enter(); //상태 시작
        Debug.Log($"Transitioned to State {newState.GetType().Name}"); //관련 내용 로그로 출력 
    }
}
