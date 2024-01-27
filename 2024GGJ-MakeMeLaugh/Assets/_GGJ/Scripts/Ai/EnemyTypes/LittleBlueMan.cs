using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.Ai
{
    public class LittleBlueMan : EnemyBase
    {
        protected override void Start()
        {
            base.Start();

            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawnedEvent();
        }

        [Button]
        public void TransferToYello()
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManChangedEvent();

            // animation

            // change to yello
        }
    }
}
