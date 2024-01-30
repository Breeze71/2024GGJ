using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace V.Ai
{
    public class LittleBlueMan : EnemyBase
    {
        public UnityEvent say;
        public MMFeedbacks changefeedback;
        [SerializeField] private Animator anim;

        protected override void Start()
        {
            base.Start();

            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawnedEvent();
        }

        [Button]
        public override void TransferToYello()
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManChangedEvent();
            changefeedback.PlayFeedbacks();
            // animation
            anim.SetBool("Change", true);
            say.Invoke();
        }
    }
}
