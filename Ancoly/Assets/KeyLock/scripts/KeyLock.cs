using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ThikkGames.GravelerGJ
{

    public class KeyLock : MonoBehaviour
    {
        public UnityEvent OnCorrectPin;

        [SerializeField]
        private string[] requiredPin;

        [SerializeField]
        private string[] currentInput;

        public void PlaceInput(int pos, string value)
        {
            currentInput[pos] = value;
            if (CheckInput())
            {
                OnCorrectPin?.Invoke();
            }
        }

        private bool CheckInput()
        {
            bool pinCorrect = true;

            for (int pos = 0; pos < requiredPin.Length; pos++)
            {
                if (requiredPin[pos] != currentInput[pos])
                {
                    pinCorrect = false;
                }
            }
            return pinCorrect;
        }

    }

}

