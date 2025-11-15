using System;
using UnityEngine;

public class UIButtonPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;     // Geschwindigkeit des Pulsens
    public float maxScale = 1.2f;     // maximale Vergrößerung
    public float minScale = 0.8f;     // minimale Verkleinerung

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale; // Startgröße merken
    }

    void Update()
    {
        // Berechne pulsierende Skalierung mit Sinusfunktion
        float scaleFactor = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f; // 0..1
        float scale = Mathf.Lerp(minScale, maxScale, scaleFactor);

        transform.localScale = initialScale * scale;
    }
}

