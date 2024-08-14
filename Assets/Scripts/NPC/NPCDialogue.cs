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
    public string Name;
    public Sprite HeadIcon;

    [Header("Interaction")]
    public bool HasInteraction;
    public DialogueType DialogueType;

    [Header("Dialogue")]
    [TextArea] public string[] Dialogue;
}
