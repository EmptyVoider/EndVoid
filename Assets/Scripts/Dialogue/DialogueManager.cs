using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public DialogueBox dialogueBox;
        public Text nameText;
        public Animator animator;

        public KeyCode NextKey = KeyCode.Return;
        public KeyCode FastForwardKey = KeyCode.Return;


        private void Update()
        {
            if (Input.GetKeyDown(NextKey))
            {
                DisplayNextSentence();
            }

            dialogueBox.SpedUp = Input.GetKey(FastForwardKey);

        }

        public void StartDialogue(Dialogue dialogue)
        {
            animator.SetBool("isOpen", true);

            nameText.text = dialogue.npcName;
        
            dialogueBox.SetDialogue(dialogue.sentences);
            dialogueBox.Speech = dialogue.sentenceSound;
            dialogueBox.ShowDialogue();

        }

        public void DisplayNextSentence()
        {
            if (dialogueBox.HasMoreDialogue)
            {
                dialogueBox.ShowDialogue();
            }
            else
            {
                EndDialogue();
            }
        }

        public void EndDialogue()
        {
            animator.SetBool("isOpen", false);
            Debug.Log("Finished conversation");
        }

    }
}