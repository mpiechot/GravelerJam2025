using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewThoughtDialogue", menuName = "Dialogue/Thought Dialogue")]
public class ThoughtDialogue : ScriptableObject
{
    [TextArea(2, 4)]
    public List<string> lines;
}

