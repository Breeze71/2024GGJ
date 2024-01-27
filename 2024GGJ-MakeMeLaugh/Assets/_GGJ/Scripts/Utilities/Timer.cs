using System;
using UnityEngine;

namespace V.Utilities
{
    public class Timer
    {
        public Timer(float _duration) 
        { 
            duration = _duration; 
        }
        
        public event Action OnTimerDone;

        private float startTime;
        private float duration;
        private float targetTime;
        private bool isActive;


        public void StartTimer()
        {
            startTime = Time.time;
            targetTime = startTime + duration;

            isActive = true;
        }
        public void StartFixedTimer()
        {
            startTime = Time.fixedDeltaTime;
            targetTime = startTime + duration;

            isActive = true;            
        }

        public void StopTimer()
        {
            isActive = false;
        }

        public void Tick()
        {
            if(!isActive)    return;

            if(Time.time >= targetTime)
            {
                StopTimer();

                OnTimerDone?.Invoke();
            }
        }
        public void FixedTick()
        {
            if(!isActive)    return;

            if(Time.fixedDeltaTime >= targetTime)
            {
                OnTimerDone?.Invoke();

                StopTimer();
            }            
        }
    }
}

