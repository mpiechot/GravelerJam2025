using UnityEngine;
using TMPro;

public class ThoughtManager : MonoBehaviour
{
    public static ThoughtManager Instance { get; private set; }

    public GameObject thoughtBubble;
    public TMP_Text thoughtText;  
    public KeyCode nextKey = KeyCode.E;

    private ThoughtDialogue currentDialogue;
    private int lineIndex = 0;
    private bool isActive = false;
    private float previousTimeScale = 1f;   // neu

    void Awake()
    {

        Instance = this;
    }

    public void StartDialogue(ThoughtDialogue dialogue)
    {

        currentDialogue = dialogue;
        lineIndex = 0;
        isActive = true;
        // Zeit anhalten
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        if (thoughtBubble != null)
            thoughtBubble.SetActive(true);

        ShowCurrentLine();
    }

    void ShowCurrentLine()
    {
        if (lineIndex < 0 || lineIndex >= currentDialogue.lines.Count) return;

        thoughtText.text = currentDialogue.lines[lineIndex];
    }

    void EndDialogue()
    {
        isActive = false;
        currentDialogue = null;
        Time.timeScale = previousTimeScale;

        if (thoughtBubble != null)
            thoughtBubble.SetActive(false);
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(nextKey))
        {
            lineIndex++;

            if (currentDialogue != null && lineIndex < currentDialogue.lines.Count)
            {
                ShowCurrentLine();
            }
            else
            {
                EndDialogue();
            }
        }
    }
}
