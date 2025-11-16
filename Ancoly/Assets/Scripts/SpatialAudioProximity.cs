using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class SpatialAudioProximity : MonoBehaviour
{
    [SerializeField] private Transform player;       // Spieler-Referenz
    [SerializeField] private float maxHearDistance = 10f; // maximale Hörweite
    [SerializeField] private float minVolumeDistance = 2f; // volle Lautstärke in dieser Nähe
    [SerializeField] private bool playOnStart = true; // Clip starten, wenn Spieler nah genug ist?

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.spatialBlend = 1f; // 3D-Sound aktivieren
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > maxHearDistance)
        {
            audioSource.volume = 0;
        }
        else
        {
            // Volume anpassen
            float volume = 1f - Mathf.InverseLerp(minVolumeDistance, maxHearDistance, distance);
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }

    // Damit der maximale Abstand im Editor sichtbar ist
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0.5f, 1f, 0.3f);
        Gizmos.DrawSphere(transform.position, maxHearDistance);
    }
}
