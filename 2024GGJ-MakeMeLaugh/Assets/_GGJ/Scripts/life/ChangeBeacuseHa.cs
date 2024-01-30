using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.TopDownEngine;
using UnityEngine;

namespace V
{
    public class ChangeBeacuseHa : MonoBehaviour
    {
        public MicrophoneManager microphoneManager;
        private CharacterMovement characterMovement;
        public MMFeedbacks Hafeedback;

        void Start()
        {
            characterMovement = GetComponent<CharacterMovement>();
        }
        void Update()
        {
            if(microphoneManager.isHappy)
            {

                Hafeedback.PlayFeedbacks();
                
                characterMovement.MovementSpeed += 3;

                microphoneManager.isHappy = false; 
            }
        }
    }
}
