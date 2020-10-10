using Dialogue;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue.Dialogue dialogue;
    private DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();//Only search for it once. Can also be a singleton
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        dialogueManager.StartDialogue(dialogue);
    }
}
