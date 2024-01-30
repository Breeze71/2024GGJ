using UnityEngine;
using Timer = V.Utilities.Timer;

namespace V
{
    [CreateAssetMenu(fileName = "IdlePatrol", menuName = "EnemySO/Idle/Patrol", order = 0)]
    public class EnemyIdlePatrol : EnemyIdleSOBase
    {
        [SerializeField] private float patrolMoveRange = 5f;
        [SerializeField] private float patrolSpeed = 1f;
        [SerializeField] private float stopBetweenPatrol = 1.5f;
        [SerializeField] private float randomPatrolTimerMax = 3f;

        private Vector3 targetPos;
        private Vector3 direction;
        private Timer timer;

        public override void DoEnterState()
        {
            base.DoEnterState();

            timer = new Timer(stopBetweenPatrol);
            timer.OnTimerDone += Timer_OnTimerDone;
            timer.StartTimer();

            targetPos = GetRandomPointCircle();
        }

        public override void DoFrameUpdate()
        {
            base.DoFrameUpdate();
            timer.Tick();

            direction = (targetPos - enemyBase.transform.position).normalized;
            enemyBase.SetVelocity(direction * patrolSpeed);

            // 到達隨機位置點後停下，開始計時(計時結束計算新位置)
            if((enemyBase.transform.position - targetPos).sqrMagnitude <= .5) // 向量轉長度
            {
                targetPos = GetRandomPointCircle();
                enemyBase.SetVelocity(Vector2.zero);
            }
        }

        public override void DoExitState()
        {
            base.DoExitState();

            timer.OnTimerDone -= Timer_OnTimerDone;
        }

        private Vector3 GetRandomPointCircle()
        {
            return enemyBase.transform.position + (Vector3)Random.insideUnitCircle * patrolMoveRange;
        }

        private void Timer_OnTimerDone()
        {
            targetPos = GetRandomPointCircle();

            timer.StartTimer();
        }
    }
}
