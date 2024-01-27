using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace V
{
    public class RemainingBlueGuysUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI remainingBlueGuysTEXT;

        private int currentBlueMan = 0;

        #region Life Cycle
        private void Awake() 
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawned += RemainBlueManEvent_OnBlueManSpawned;
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManDecreased += RemainBlueManEvent_OnBlueManDecreased;
        }
        private void Start() 
        {
            UpdateRemainingBlueTEXT();    
        }
        private void OnDestroy()
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawned -= RemainBlueManEvent_OnBlueManSpawned;
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManDecreased -= RemainBlueManEvent_OnBlueManDecreased;
        }
        #endregion

        private void RemainBlueManEvent_OnBlueManSpawned()
        {
            currentBlueMan += 1;

            UpdateRemainingBlueTEXT();
        }
        private void RemainBlueManEvent_OnBlueManDecreased()
        {
            currentBlueMan -= 1;

            UpdateRemainingBlueTEXT();

            if(currentBlueMan == 0)
            {
                GameEventsManager.Instance.RemainBlueManEvent.OnAllBlueManTransferEvent();
            }
        }

        private void UpdateRemainingBlueTEXT()
        {
            remainingBlueGuysTEXT.text = "Remaining Blue Guys: " + currentBlueMan;
        }
    }
}
