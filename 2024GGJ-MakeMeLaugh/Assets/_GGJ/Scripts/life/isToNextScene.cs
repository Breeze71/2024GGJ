using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

namespace V
{
    public class isToNextScene : MonoBehaviour
    {   
        public Animator anim;
        public MicrophoneManager microphoneManager;
        public UnityEvent toNextEvent;

        // Update is called once per frame
        void Update()
        {
            if(microphoneManager.isHappy)
            {   
                
                anim.SetBool("isbegin",true);
                StartCoroutine(DelayedInvoke());
            }
             IEnumerator DelayedInvoke()
            {   
            yield return new WaitForSeconds(0.7f); // 等待两秒

            // 触发 toNextEvent
            toNextEvent.Invoke();
            }
        
        }
    }
}
