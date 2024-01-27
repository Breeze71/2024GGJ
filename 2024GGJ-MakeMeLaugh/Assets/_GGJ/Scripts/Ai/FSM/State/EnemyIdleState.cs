using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    /// <summary>
    /// 改為固定巡邏路線，或是預生成路線
    /// </summary>
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(EnemyBase _enemyBase, EnemyStateMachine _enemyStateMachine) : base(_enemyBase, _enemyStateMachine)
        {
        }

        public override void EnterState() 
        {
            base.EnterState();

            enemyBase.EnemyIdleBaseInstance.DoEnterState();
        }
        
        public override void FrameUpdate() 
        {
            base.FrameUpdate();

            enemyBase.EnemyIdleBaseInstance.DoFrameUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            enemyBase.EnemyIdleBaseInstance.DoPhysicsUpdate();
        }

        public override void ExitState()
        {
            base.ExitState();

            enemyBase.EnemyIdleBaseInstance.DoExitState();
        }

        public override void AnimTriggerEvent(EnemyBase.AnimTriggerTypes _triggerTypes)
        {
            base.AnimTriggerEvent(_triggerTypes);

            enemyBase.EnemyIdleBaseInstance.DoAnimTriggerEvent(_triggerTypes);
        }
    }
}
