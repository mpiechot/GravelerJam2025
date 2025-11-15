using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ThikkGames.GravelerGJ
{

    public class KeyLockPos : MonoBehaviour
    {
        public UnityEvent<string> OnDownPosChanged;
        public UnityEvent<string> OnUpPosChanged;
        public UnityEvent<int, string> OnAnimationEnd;
        public UnityEvent<string> OnAnimationEndStringNotification;

        [SerializeField]
        private int maxValue = 10;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private int pos = 0;

        private int currentValue = 0;

        private bool noAnimationRunning = true;

        public void OnChangeValue(int direction)
        {
            if (noAnimationRunning)
            {
                currentValue = (currentValue + direction) % maxValue;
                currentValue = currentValue < 0 ? maxValue - 1 : currentValue;
                if (direction > 0)
                {
                    OnDownPosChanged?.Invoke(currentValue.ToString());
                    animator.SetTrigger("PinChangeUp");
                }
                else
                {
                    OnUpPosChanged?.Invoke(currentValue.ToString());
                    animator.SetTrigger("PinChangeDown");
                }
                
                noAnimationRunning = false;
            }
            
        }

        public void AnimationEnd()
        {
            Debug.Log("On End:" + currentValue);
            OnAnimationEnd?.Invoke(pos, currentValue.ToString());
            OnAnimationEndStringNotification?.Invoke(currentValue.ToString());
            noAnimationRunning = true;
        }



    }
}

