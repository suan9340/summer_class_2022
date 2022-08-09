using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Commands
{
    public abstract void Execute(Animator _anim, bool _bFoward);

    public abstract void Undo(Animator _anim);
}

public class PerformJump : Commands
{
    public override void Execute(Animator _anim, bool _bFoward)
    {
        Debug.Log($"||isJumping Excute||");

        if (_bFoward)
            _anim.SetTrigger("isJumping");
        else
            _anim.SetTrigger("isJumpingR");
    }

    public override void Undo(Animator _anim)
    {
        Debug.Log($"||isJumping Undo||");

        _anim.SetTrigger("isKicking");
    }
}

public class PerformKick : Commands
{
    public override void Execute(Animator _anim, bool _bFoward)
    {
        Debug.Log($"||isKicking Excute||");

        if( _bFoward)
        _anim.SetTrigger("isKicking");
        else
            _anim.SetTrigger("isKickingR");
    }

    public override void Undo(Animator _anim)
    {
        Debug.Log($"||isKicking Undo||");

        _anim.SetTrigger("isJumping");
    }
}

public class PerformPunch : Commands
{
    public override void Execute(Animator _anim, bool _bFoward)
    {
        Debug.Log($"||isPunching Excute||");

        if(_bFoward)
        _anim.SetTrigger("isPunching");
        else
            _anim.SetTrigger("isPunchingR");
    }

    public override void Undo(Animator _anim)
    {
        Debug.Log($"||isPunching Undo||");

        _anim.SetTrigger("isWalking");
    }
}

public class DoNothing : Commands
{
    public override void Execute(Animator _anim, bool _bFoward)
    {

    }

    public override void Undo(Animator _anim)
    {

    }
}

public class MoveForward : Commands
{
    public override void Execute(Animator _anim, bool _bFoward)
    {
        Debug.Log($"||isWalking Excute||");

        if(_bFoward)
        _anim.SetTrigger("isWalking");
        else
            _anim.SetTrigger("isWalkingR");
    }

    public override void Undo(Animator _anim)
    {
        Debug.Log($"||isWalking Undo||");

        _anim.SetTrigger("isPunching");
    }
}
