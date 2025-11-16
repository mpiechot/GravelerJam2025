using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectPlayer : MonoBehaviour
{
    public List<SoundEffect> soundEffects = new List<SoundEffect>();
    private AudioSource audioSource;
    private Dictionary<SoundType, AudioClip> clipLibrary;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        clipLibrary = new Dictionary<SoundType, AudioClip>();

        foreach (var sfx in soundEffects)
        {
            if (!clipLibrary.ContainsKey(sfx.type) && sfx.clip != null)
            {
                clipLibrary.Add(sfx.type, sfx.clip);
            }
        }
    }

    public void PlaySound(SoundType soundType, float volume = 1f)
    {
        if (clipLibrary.TryGetValue(soundType, out var clip))
        {
            audioSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning($"SoundEffectPlayer: Kein Sound mit Namen '{soundType}' gefunden.");
        }
    }
}

