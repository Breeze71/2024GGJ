

namespace V
{
    public class EnemyState
    {
        protected EnemyBase enemyBase;
        protected EnemyStateMachine enemyStateMachine;

        public EnemyState(EnemyBase _enemyBase, EnemyStateMachine _enemyStateMachine)
        {
            enemyBase = _enemyBase;
            enemyStateMachine = _enemyStateMachine;
        }

        public virtual void EnterState() {}
        public virtual void ExitState() {}
        public virtual void FrameUpdate() {}
        public virtual void PhysicsUpdate() {}
        public virtual void AnimTriggerEvent(EnemyBase.AnimTriggerTypes _triggerTypes) {}
    }
}
