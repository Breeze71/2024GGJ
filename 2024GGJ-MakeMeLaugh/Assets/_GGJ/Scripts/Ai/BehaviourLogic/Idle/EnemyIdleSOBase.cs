using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class EnemyIdleSOBase : ScriptableObject 
    {
        protected EnemyBase enemyBase;
        protected Transform transform;  // SO 沒有 trasnform
        protected GameObject gameObject;

        protected Transform playerTransform;

        public virtual void Initialize(GameObject _gameObject, EnemyBase _enemyBase)
        {
            gameObject = _gameObject;
            transform = gameObject.transform;
            enemyBase = _enemyBase;

            playerTransform = enemyBase.PlayerTransform; 
        }

        public virtual void DoEnterState() {}
        public virtual void DoExitState() { ResetValue(); }
        public virtual void DoFrameUpdate() 
        {
            if(enemyBase.IsInLaughRange)
            {
                enemyBase.StateMachine.ChangeState(enemyBase.ChaseState);
            }
        }
        public virtual void DoPhysicsUpdate() {}
        public virtual void DoAnimTriggerEvent(EnemyBase.AnimTriggerTypes _triggerTypes) {}
        public virtual void ResetValue() {}
    }
}
