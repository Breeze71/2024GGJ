using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    [CreateAssetMenu(fileName = "Chase", menuName = "EnemySO/Chase/ChasePlayer", order = 0)]
    public class EnemyChasePlayer : EnemyChaseSOBase
    {
        [SerializeField] private float burstSpeed = 5f;

        private float randomMoveRange;
        private Vector3 targetPos;
        private Vector3 direction;

        public override void DoEnterState()
        {
            base.DoEnterState();

            targetPos = GetRandomPointCircle();

            direction = (targetPos - enemyBase.transform.position).normalized;

            enemyBase.Rb.AddForce(direction * burstSpeed);
        }

        public override void DoFrameUpdate()
        {
            base.DoFrameUpdate();
        }

        private Vector3 GetRandomPointCircle()
        {
            return enemyBase.transform.position + (Vector3)Random.insideUnitCircle * randomMoveRange;
        }
    }
}
