using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace V
{
    public class isToNextScene : MonoBehaviour
    {   
        public MicrophoneManager microphoneManager;
        public UnityEvent toNextEvent;

        // Update is called once per frame
        void Update()
        {
            if(microphoneManager.isHappy)
            {
                toNextEvent.Invoke();
            }
        
        }
    }
}
