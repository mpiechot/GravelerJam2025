using UnityEngine;

public class ShakeAroundOrigin : MonoBehaviour
{
    public float shakeAmount = 0.05f;  // maximale Auslenkung
    public float shakeSpeed = 5f;      // Geschwindigkeit des Wackelns

    private Vector3 originalPosition;
    private float seedX;
    private float seedY;

    void Start()
    {
        originalPosition = transform.localPosition;

        // Individueller Seed je Objekt basierend auf Position und Zufall
        seedX = Random.Range(0f, 1000f);
        seedY = Random.Range(0f, 1000f);
    }

    void Update()
    {
        Vector3 randomOffset = new Vector3(
            Mathf.PerlinNoise(seedX, Time.time * shakeSpeed) - 0.5f,
            Mathf.PerlinNoise(seedY, Time.time * shakeSpeed) - 0.5f,
            0f
        ) * shakeAmount;

        transform.localPosition = originalPosition + randomOffset;
    }
}
