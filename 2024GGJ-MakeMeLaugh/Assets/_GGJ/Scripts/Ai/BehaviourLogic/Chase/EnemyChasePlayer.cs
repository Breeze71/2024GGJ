using UnityEngine;
using V.Utilities;

namespace V
{
    [CreateAssetMenu(fileName = "Chase", menuName = "EnemySO/Chase/ChasePlayer", order = 0)]
    public class EnemyChasePlayer : EnemyChaseSOBase
    {
        [SerializeField] private float dashSpeed = 10f;
        [SerializeField] private float dashTimerMax = 1.5f;
        [SerializeField] private float patrolSpeed = 5f;
        [SerializeField] private float randomMoveRange = 5f;

        private Vector3 targetPos;
        private Vector3 direction;

        private Timer timer;
        private bool isDashTimerDone = false;

        public override void DoEnterState()
        {
            base.DoEnterState();

            timer = new Timer(dashTimerMax);
            timer.OnTimerDone += Timer_OnTimerDone;
            timer.StartTimer();

            targetPos = GetRandomPointCircle();
            direction = (targetPos - enemyBase.transform.position).normalized;

            enemyBase.DashSquashStretch.PlaySquashAndStretch();
            enemyBase.TransferToYello();
        }


        public override void DoFrameUpdate()
        {
            base.DoFrameUpdate();
            timer.Tick();

            if(!isDashTimerDone)
            {
                enemyBase.Rb.AddForce(dashSpeed * direction);

                return;
            }

            direction = (targetPos - enemyBase.transform.position).normalized;
            enemyBase.SetVelocity(direction * patrolSpeed);
            
            // back to random patrol
            if((enemyBase.transform.position - targetPos).sqrMagnitude <= .5) // 向量轉長度
            {
                enemyBase.SetVelocity(Vector2.zero);
                targetPos = GetRandomPointCircle();

                return;
            }
        }

        public override void DoExitState()
        {
            base.DoExitState();

            timer.OnTimerDone -= Timer_OnTimerDone;
        }

        private void Timer_OnTimerDone()
        {
            isDashTimerDone = true;
            enemyBase.SetVelocity(Vector2.zero);
            targetPos = GetRandomPointCircle();

            timer.StartTimer();
        }
        private Vector3 GetRandomPointCircle()
        {
            return enemyBase.transform.position + (Vector3)Random.insideUnitCircle * randomMoveRange;
        }
    }
}
