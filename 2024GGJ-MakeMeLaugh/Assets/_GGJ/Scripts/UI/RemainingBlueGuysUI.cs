using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace V
{
    public class RemainingBlueGuysUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI remainingBlueGuysTEXT;
        [SerializeField] private GameObject winUI;

        private int currentBlueMan = 0;
        public UnityEvent delectevent;


        #region Life Cycle
        private void Awake() 
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawned += RemainBlueManEvent_OnBlueManSpawned;
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManDecreased += RemainBlueManEvent_OnBlueManDecreased;
            GameEventsManager.Instance.RemainBlueManEvent.OnAllBlueManTransfer += RemainBlueManEvent_OnAllBlueManTransfer;
        }

        private void RemainBlueManEvent_OnAllBlueManTransfer()
        {
            winUI.SetActive(true);
        }

        private void Start() 
        {
            UpdateRemainingBlueTEXT();    
        }
        private void OnDestroy()
        {
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManSpawned -= RemainBlueManEvent_OnBlueManSpawned;
            GameEventsManager.Instance.RemainBlueManEvent.OnBlueManDecreased -= RemainBlueManEvent_OnBlueManDecreased;
            GameEventsManager.Instance.RemainBlueManEvent.OnAllBlueManTransfer -= RemainBlueManEvent_OnAllBlueManTransfer;
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
                delectevent.Invoke();
            }
        }

        private void UpdateRemainingBlueTEXT()
        {
            remainingBlueGuysTEXT.text = "Remaining Blue Guys: " + currentBlueMan;
        }
    }
}
