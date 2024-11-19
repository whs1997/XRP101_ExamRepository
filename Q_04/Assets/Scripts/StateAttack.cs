using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }
    /*
    public override void Exit()
    {
        
    }
    */
    private void Attack()
    {
        // �÷��̾��� ��ġ���� radius ���� Ž��
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            // damagable�� null�� �˻縦 �߰�
            if (damagable != null)
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }
        // Exit()���� �ڵ� �̵�
        Machine.ChangeState(StateType.Idle);
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        //Exit();
    }

}
