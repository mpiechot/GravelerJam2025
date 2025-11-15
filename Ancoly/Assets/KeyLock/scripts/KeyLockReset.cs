using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ThikkGames.GravelerGJ
{

    public class KeyLockReset : MonoBehaviour
    {

        private Vector3 initialPosition;
        private Vector3 initialScale;
        
        // Start is called before the first frame update
        void Start()
        {
            initialPosition = GetComponent<RectTransform>().anchoredPosition;
            initialScale = GetComponent<RectTransform>().sizeDelta;
        }

        
        public void ResetValues()
        {
            GetComponent<RectTransform>().anchoredPosition = initialPosition;
            GetComponent<RectTransform>().sizeDelta = initialScale;
        }

    }


}
