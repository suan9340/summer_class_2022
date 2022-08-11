using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum eState
    {
        IDLE,
        TRACE,
        PARSUE,
        ATTACK,
        SLEEP,
        RUNAWAY,
    }

    public enum eEvent
    {
        ENTER,
        UPDATE,
        EXIT,
    }

    public eState stateNamt;
    protected eEvent curEvent;
    protected GameObject myObj;
    protected NavMeshAgent myAgent;
    protected Animator myAnim;
    protected Transform playerTrn;
    protected State nextState;
    float detectDist = 10.0f;
    float detectAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject _obj, NavMeshAgent _agent, Animator _anim, Transform _targetTrn)
    {
        myObj = _obj;
        myAgent = _agent;
        myAnim = _anim;
        playerTrn = _targetTrn;

        curEvent = eEvent.ENTER;
    }

    public virtual void Enter() { curEvent = eEvent.UPDATE; }
    public virtual void Update() { curEvent = eEvent.UPDATE; }
    public virtual void Exit() { curEvent = eEvent.EXIT; }

    public State Process()
    {
        if (curEvent == eEvent.ENTER) Enter();
        if (curEvent == eEvent.UPDATE) Update();
        if(curEvent == eEvent.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }

}

public class Idle : State
{
    public Idle(GameObject _obj, NavMeshAgent _agent, Animator _anim, Transform _targetTrn)
        :base(_obj,_agent,_anim, _targetTrn)
    {
        stateNamt = eState.IDLE;
    }

    public override void Enter()
    {
        myAnim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        // 기본상태일 때 처리
    }

    public override void Exit()
    {
        myAnim.SetTrigger("isIdle");
        base.Exit();
    }
}
