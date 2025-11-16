using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [Header("Bubble Sprites (3 Teile)")]
    [SerializeField] private SpriteRenderer bubblePart1;
    [SerializeField] private SpriteRenderer bubblePart2;
    [SerializeField] private SpriteRenderer bubblePart3;

    [Header("Text in der Bubble")]
    [SerializeField] private TMP_Text bubbleText;

    [Header("Dialog-Texte")]
    public List<string> texts = new List<string>();

    [Header("Timings")]
    [SerializeField] private float minWaitBeforeBubble = 2f;
    [SerializeField] private float maxWaitBeforeBubble = 5f;
    [SerializeField] private float textDisplayTime = 3f;
    [SerializeField] private float buildDurationPerPart = 0.15f;
    [SerializeField] private float dissolveDuration = 0.2f;

    private Vector3 originalScale1, originalScale2, originalScale3, textOriginalScale;

    private void Awake()
    {
        originalScale1 = bubblePart1.transform.localScale;
        originalScale2 = bubblePart2.transform.localScale;
        originalScale3 = bubblePart3.transform.localScale;
        textOriginalScale = bubbleText.transform.localScale;

        HideInstant();
    }

    private void Start()
    {
        if (texts != null && texts.Count > 0)
            StartCoroutine(BubbleLoopRoutine());
    }

    private IEnumerator BubbleLoopRoutine()
    {
        while (true) // Endlos-Schleife
        {
            foreach (var text in texts)
            {
                yield return new WaitForSeconds(Random.Range(minWaitBeforeBubble, maxWaitBeforeBubble));

                yield return StartCoroutine(BuildBubbleSequential());

                bubbleText.text = text;
                bubbleText.enabled = true;

                yield return new WaitForSeconds(textDisplayTime);

                bubbleText.enabled = false;

                yield return StartCoroutine(DissolveBubble());
            }
        }
    }

    private IEnumerator BubbleRoutine()
    {
        foreach (var text in texts)
        {
            yield return new WaitForSeconds(Random.Range(minWaitBeforeBubble, maxWaitBeforeBubble));

            // Build Bubble nacheinander
            yield return StartCoroutine(BuildBubbleSequential());

            // Show text
            bubbleText.text = text;
            bubbleText.enabled = true;

            yield return new WaitForSeconds(textDisplayTime);

            // Hide text
            bubbleText.text = "";
            bubbleText.enabled = false;

            // Dissolve Bubble
            yield return StartCoroutine(DissolveBubble());
        }
    }

    private IEnumerator BuildBubbleSequential()
    {
        EnableRenderers(true);

        // Part 1
        yield return ScalePart(bubblePart1, Vector3.zero, originalScale1);

        // Part 2
        yield return ScalePart(bubblePart2, Vector3.zero, originalScale2);

        // Part 3
        yield return ScalePart(bubblePart3, Vector3.zero, originalScale3);

        // Full Bubble, then scale text
        float time = 0f;
        while (time < buildDurationPerPart)
        {
            time += Time.deltaTime;
            bubbleText.transform.localScale = Vector3.Lerp(Vector3.zero, textOriginalScale, time / buildDurationPerPart);
            yield return null;
        }
    }

    private IEnumerator ScalePart(SpriteRenderer part, Vector3 start, Vector3 end)
    {
        float time = 0f;
        while (time < buildDurationPerPart)
        {
            time += Time.deltaTime;
            part.transform.localScale = Vector3.Lerp(start, end, time / buildDurationPerPart);
            yield return null;
        }
        part.transform.localScale = end;
    }

    private IEnumerator DissolveBubble()
    {
        float time = 0f;

        Vector3 zero = Vector3.zero;
        while (time < dissolveDuration)
        {
            time += Time.deltaTime;
            float t = time / dissolveDuration;

            bubblePart1.transform.localScale = Vector3.Lerp(originalScale1, zero, t);
            bubblePart2.transform.localScale = Vector3.Lerp(originalScale2, zero, t);
            bubblePart3.transform.localScale = Vector3.Lerp(originalScale3, zero, t);
            bubbleText.transform.localScale = Vector3.Lerp(textOriginalScale, zero, t);

            yield return null;
        }

        HideInstant();
    }

    private void HideInstant()
    {
        bubblePart1.transform.localScale = Vector3.zero;
        bubblePart2.transform.localScale = Vector3.zero;
        bubblePart3.transform.localScale = Vector3.zero;
        bubbleText.transform.localScale = Vector3.zero;

        bubbleText.enabled = false;
        EnableRenderers(false);
    }

    private void EnableRenderers(bool enabled)
    {
        bubblePart1.enabled = enabled;
        bubblePart2.enabled = enabled;
        bubblePart3.enabled = enabled;
    }
}
