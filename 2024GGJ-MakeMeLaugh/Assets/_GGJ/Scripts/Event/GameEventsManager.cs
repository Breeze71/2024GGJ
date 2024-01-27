using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class GameEventsManager : MonoBehaviour
    {
        public static GameEventsManager Instance { get; private set; }

        public RemainBlueManEvent RemainBlueManEvent;

        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("More than One GameEvent Manager");
            }    

            Instance = this;

            RemainBlueManEvent = new RemainBlueManEvent();
        }
    }
}
