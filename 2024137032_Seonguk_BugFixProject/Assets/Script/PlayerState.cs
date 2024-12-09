using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;  //상태머신에 대한 참조
    protected PlayerController playerController; //플레이어 컨트롤러에 대한 참조 
    protected PlayerAnimationManager animationManager;

    public PlayerState(PlayerStateMachine stateMachine)  //상태 머신과 플레이어 컨트롤러 참조 초기화 
    {
        this.stateMachine = stateMachine;
        this.playerController = stateMachine.playerController;
        this.animationManager = stateMachine.GetComponent<PlayerAnimationManager>();
    }

    public class IdleState : PlayerState
    {
        private bool isRunning;
        public IdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        
        public override void Update()
        {
            //달리기 입력 확인 
            isRunning = Input.GetKey(KeyCode.LeftShift);

            CheckTransitions();  //매 프레임 마다 상태 전환 조건 체크
        }        
    }
    public class MoveingState : PlayerState
    {
        public MoveingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Update()
        {
            CheckTransitions();  //매 프레임 마다 상태 전환 조건 체크
        }
        public override void FixedUpdate()
        {
            playerController.HandleMovement(); //물리 기반 이동 처리 
        }
    }

    //MoveingState : 플레이어가 이동중인 상태 
    public class FallingState : PlayerState
    {
        public FallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Update()
        {
            CheckTransitions();  //매 프레임마다 상태 전환 조건 체크  
        }

        public override void FixedUpdate()
        {
            playerController.HandleMovement(); //물리 기반 이동 처리 
        }
    }

    public class JumpingState : PlayerState
    {
        public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Update()
        {
            CheckTransitions();  //매 프레임마다 상태 전환 조건 체크  
        }

        public override void FixedUpdate()
        {
            playerController.HandleMovement(); //물리 기반 이동 처리 
        }
    }

        //가상 메서드들 : 하위 클래스에서 필요에 따라 오버라이드 

    public virtual void Enter() { } //상태 진입 시 호출 
    public virtual void Exit() { } //상태 종료 시 호출 
    public virtual void Update() { } //매 프레일 호출 
    public virtual void FixedUpdate() { } //고정 시간 간격으로 호출(물리 연산용)
    
    // 상태 전환 조건은 체크하는 메서드 
    protected void CheckTransitions()
    {
        if(playerController.isGrounded())  //지상에 있을 때의 전환 로직 
        {
            if(Input.GetKeyDown(KeyCode.Space))  //점프키를 눌렀을 때 
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine)); 
            }
            else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical!") != 0)  //이동키가 눌렸을 때 
            {
                stateMachine.TransitionToState(new MoveingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new IdleState(stateMachine));  //아무키도 누르지 않았을 때 
            }
        }
        else
        {
            if(playerController.GetVerticalVelocity() > 0)  //Y축 이동 속도 값이 양수 일 때 점프중 
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else //Y축 이동 속도 값이 음수 일 때 점프중 
            { 
                stateMachine.TransitionToState(new FallingState(stateMachine));
            }
        }
    }
    
}
