using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class RemainBlueManEvent
    {
        /// <summary>
        /// 當生成新 Blue Man 時
        /// </summary>
        public event Action OnBlueManSpawned;
        public void OnBlueManSpawnedEvent()
        {
            OnBlueManSpawned?.Invoke();
        }

        
        public event Action OnBlueManDecreased;

        public void OnBlueManChangedEvent()
        {
            OnBlueManDecreased?.Invoke();
        }

        public event Action OnAllBlueManTransfer;
        public void OnAllBlueManTransferEvent()
        {
            OnAllBlueManTransfer.Invoke();
        }
    }
}
