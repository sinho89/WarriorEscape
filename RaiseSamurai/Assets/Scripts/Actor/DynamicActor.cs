using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicActor : BaseActor
{
    public Defines.ActorStates ActorStateType { get; protected set; } = Defines.ActorStates.Move;
    public Animator Actoranim { get; protected set; }

    protected int _attackType = 0;
    protected bool _isMove = true;
    protected bool _isAttack = false;
    protected bool _isDeath = false;
    protected bool _isDyingComplete = false;

    public float MoveSpeed { get; protected set; } = 1.0f;
    public int MaxHp { get; protected set; } = 100;
    public int Hp { get; protected set; } = 100;
    public int MaxMp { get; protected set; } = 50;
    public int Mp { get; protected set; } = 50;
    public int Attack { get; protected set; } = 10;
    public float AttackSpeed { get; protected set; } = 1.0f;
    public int Level { get; protected set; } = 1;
    public int MaxExp { get; protected set; } = 10;
    public int Exp { get; protected set; } = 0;
    

    public virtual void OnEnable()
    {
        Hp = MaxHp;
        Mp = MaxMp;
        ActorStateType = Defines.ActorStates.Move;
    }

    public virtual void Hit(int attack)
    {
        if(Hp > 0)
            Hp -= attack;
    }

    protected override void Init()
    {
        base.Init();

        Actoranim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        AnimStateUpdate();
    }
    protected virtual void AnimStateUpdate()
    {   
        switch (ActorStateType)
        {
            case Defines.ActorStates.Move:
                _isMove = true;
                _isAttack = false;
                _isDeath = false;
                _attackType = 0;
                Actoranim.speed = 1.0f;
                break;

            case Defines.ActorStates.Attack1:
                _isMove = false;
                _isAttack = true;
                _isDeath = false;
                _attackType = 1;
                Actoranim.speed = AttackSpeed;
                break;

            case Defines.ActorStates.Attack2:
                _isMove = false;
                _isAttack = true;
                _isDeath = false;
                _attackType = 2;
                Actoranim.speed = AttackSpeed;
                break;

            case Defines.ActorStates.Death:
                _isMove = false;
                _isAttack = false;
                _isDeath = true;
                _attackType = 0;
                Actoranim.speed = 0.25f;
                break;

        }

        Actoranim.SetBool("IsMove", _isMove);
        Actoranim.SetBool("IsAttack", _isAttack);
        Actoranim.SetBool("IsDeath", _isDeath);
        Actoranim.SetInteger("AttackType", _attackType);
    }

    protected virtual void OnAttack()
    {
        Managers.Actor.AttackTarget(ActType, Attack);
    }
    protected virtual void OnDeath()
    {

    }
    public override void Clear()
    {

    }
}
