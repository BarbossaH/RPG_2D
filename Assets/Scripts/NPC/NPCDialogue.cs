using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueType
{
    Quest,
    Shop
}

[CreateAssetMenu(menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    [Header("Info")]
    public string NpcName;
    public Sprite HeadIcon;

    [Header("Interaction")]
    public bool HasInteraction;
    public DialogueType DialogueType;

    [Header("Dialogue")]
    public string GreetingText;
    [TextArea] public string[] DialogueArray;
}
