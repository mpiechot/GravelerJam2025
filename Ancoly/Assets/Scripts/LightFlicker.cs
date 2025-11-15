using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightFlicker : MonoBehaviour
{
    private Light2D light2D;
    [SerializeField]
    private AudioSource audioSource;

    [Header("Flacker-Einstellungen")]
    public float minIntensity = 0.0f;  // minimale Lichtintensität
    public float maxIntensity = 1.8f;  // maximale Lichtintensität
    public float minTime = 0.05f;      // minimale Zeit zwischen Flackern
    public float maxTime = 0.2f;       // maximale Zeit zwischen Flackern
    public float sensitivity = 5f;     // Audio-Reaktivität

    private float nextFlickerTime;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        if (audioSource == null)
        {
            ScheduleNextFlicker();
        }
    }

    void Update()
    {
        if (audioSource != null)
        {
            FlickerToAudio();
        }
        else
        {
            if (Time.time >= nextFlickerTime)
            {
                FlickerRandomly();
                ScheduleNextFlicker();
            }
        }
    }

    void FlickerToAudio()
    {
        float[] samples = new float[64];
        audioSource.GetOutputData(samples, 0);

        float level = 0f;
        foreach (float sample in samples)
            level += Mathf.Abs(sample);

        level /= samples.Length;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, level * sensitivity);
        light2D.intensity = intensity;
    }

    void FlickerRandomly()
    {
        light2D.intensity = UnityEngine.Random.Range(minIntensity, maxIntensity);
    }

    void ScheduleNextFlicker()
    {
        nextFlickerTime = Time.time + UnityEngine.Random.Range(minTime, maxTime);
    }
}
