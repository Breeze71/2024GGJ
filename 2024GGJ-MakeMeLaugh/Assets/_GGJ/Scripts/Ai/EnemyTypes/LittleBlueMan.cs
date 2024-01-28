using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.Ai
{
    public class LittleBlueMan : EnemyBase
    {

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField, ColorUsage(true, true)] private Color color;

        protected override void Start()
        {
            base.Start();

            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawnedEvent();
        }

        // [Button]
        public override void TransferToYello()
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManChangedEvent();

            // animation
            spriteRenderer.color = color;

            // change to yello
        }
    }
}
