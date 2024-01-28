using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

namespace V
{
    public class ChangeBeacuseHa : MonoBehaviour
    {
        public MicrophoneManager microphoneManager;
        private CharacterMovement characterMovement;
        void Start()
        {
            characterMovement = GetComponent<CharacterMovement>();
        }
        void Update()
        {
            if(microphoneManager.isHappy)
            {
                characterMovement.WalkSpeed = 1.5f * characterMovement.WalkSpeed;

                microphoneManager.isHappy = false; 
            }
        }
    }
}
