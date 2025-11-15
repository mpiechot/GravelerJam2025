using System;
using UnityEngine;

using UnityEngine.Rendering.Universal; // Für 2D-Lights

[RequireComponent(typeof(Light2D))]
public class LightFlicker : MonoBehaviour
{
    private Light2D light2D;

    [Header("Flacker-Einstellungen")]
    public float minIntensity = 0.0f;  // minimale Lichtintensität
    public float maxIntensity = 1.8f;  // maximale Lichtintensität
    public float minTime = 0.05f;      // minimale Zeit zwischen Flackern
    public float maxTime = 0.2f;       // maximale Zeit zwischen Flackern

    private float nextFlickerTime;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        ScheduleNextFlicker();
    }

    void Update()
    {
        if (Time.time >= nextFlickerTime)
        {
            Flicker();
            ScheduleNextFlicker();
        }
    }

    void Flicker()
    {
        // Unregelmäßige Intensität zwischen min und max
        light2D.intensity = UnityEngine.Random.Range(minIntensity, maxIntensity);

        // Optional: leicht die Position rotieren für schummriges Licht
        // Vector3 rotationOffset = new Vector3(0, 0, Random.Range(-2f, 2f));
        // light2D.transform.localEulerAngles = rotationOffset;
    }

    void ScheduleNextFlicker()
    {
        nextFlickerTime = Time.time + UnityEngine.Random.Range(minTime, maxTime);
    }
}

