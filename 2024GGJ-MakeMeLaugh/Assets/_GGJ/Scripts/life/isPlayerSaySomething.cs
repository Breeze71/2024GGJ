using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class isPlayerSaySomething : MonoBehaviour
    {
        private Animator anim;
        
        public MicrophoneManager microphoneManager;


        // Start is called before the first frame update
        void Start()
        {   
            anim = GetComponent<Animator>();
        
        }

        // Update is called once per frame
        void Update()
        {
            if(microphoneManager.isHappy)
            {
                anim.SetBool("ishappy",true);
            }
            else
            {
                anim.SetBool("ishappy",false);
            }
        
        }
    }
}
