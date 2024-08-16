using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    //this class is responsible for setting the data of the current selected NPC into the memory, and responding the Key Board events to show the data in the interface. 
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npmNameTMP;
    [SerializeField] private TextMeshProUGUI npcDialogueTMP;

    public NPCInteraction NPCSelected { get; set; }

    private PlayerActions actions;
    private Queue<string> dialogueQueue = new Queue<string>();

    private bool dialogueStarted;
    protected override void Awake()
    {
        base.Awake();
        actions = new PlayerActions();
    }
    private void Start()
    {
        actions.Dialogue.Interact.performed += ctx => ShowDialogue();
        actions.Dialogue.Continue.performed += ctx => ContinueDialogue();
    }

    private void LoadDialogueFromNpc()
    {
        if (NPCSelected.DialogueToShow.DialogueArray.Length > 0)
        {
            foreach (string sentence in NPCSelected.DialogueToShow.DialogueArray)
            {
                dialogueQueue.Enqueue(sentence);
            }
        }
    }

    private void ClearDialogueFromNpc()
    {
        dialogueQueue.Clear();
        dialogueStarted = false;
        dialoguePanel.SetActive(false);
    }


    private void ShowDialogue()
    {
        //this is for starting a new dialogue, it is like initiating a new dialogue and initializing all relevant variables. Here, I will show the UI and the default dialogue text such as greeting text.
        if (NPCSelected == null) return;
        if (dialogueStarted) return;
        dialoguePanel.SetActive(true);

        npcIcon.sprite = NPCSelected.DialogueToShow.HeadIcon;
        npmNameTMP.text = NPCSelected.DialogueToShow.NpcName;
        npcDialogueTMP.text = NPCSelected.DialogueToShow.GreetingText;
        //update the state of conversation
        dialogueStarted = true;
    }
    private void ContinueDialogue()
    {
        //this is for show the actual dialogue text which can show the real purpose on this dialogue, and managing the dialogue UI.
        if (NPCSelected == null || dialogueQueue.Count <= 0)
        {
            ClearDialogueFromNpc();
            return;
        }
        npcDialogueTMP.text = dialogueQueue.Dequeue();
    }
    public void InitiateDialogue(NPCInteraction npc)
    {
        NPCSelected = npc;
        LoadDialogueFromNpc();
    }
    public void EndDialogue()
    {
        NPCSelected = null;
        ClearDialogueFromNpc();
    }
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

}
