using System;
using UnityEngine;

namespace Dialog
{
    [RequireComponent(typeof(DialogBox))]
    public class DialogControl : MonoBehaviour
    {

        public KeyCode NextKey = KeyCode.Return;
        public KeyCode FastForwardKey = KeyCode.Return;
        private DialogBox dialogBox;

        private void Awake()
        {
            this.dialogBox = GetComponent<DialogBox>();
        }

        private void Start()
        {
            dialogBox.SetDialog(GetLines());
            dialogBox.ShowDialog();
        }

        private string[] GetLines()
        {
            //TODO I want to pull this from a text file or even use a dialog system like Ink
            return new [] {
                    "Hi!, this is my dialog box/speech bubble. Hit Enter to proceed to the next batch of lines.",
                    "It's not very advanced - yet! but I have some ideas for it, to make it a bit \"cooler\" as the kids say.",
                    "Maybe have it resize depending on the content size i.e. number of characters/words, or maybe have it inside the game space and not a UI element, so when the player walks away from a talking character the box stays close to the character.",
                    "But lets not think about what we <b>don't</b> have and focus on what we <b>do</b> have.",
                    "Saw that? some words can be <b>bold</b>. We can even do <I>Italic if you're feeling fancy</I> or put it a bit of <color=yellow>c</color><color=orange>o</color><color=green>l</color><color=purple>o</color><color=red>r</color>.",
                    "As you can probably hear, the text plays a speaking sound effect, but it's in a constant loop that cuts off in an unnatural way. To fix it I need th sound effect to be split to different clips with a single vowel in each",
                    "You can configure which button is the next button and which button speeds up, as well as the default speed.",
                    "Oh, did I not tell you you can speed up? right now it's set to the same button, so hold Enter.",
                    "The speed is configured by the number of characters per second, and with the speed up its 3 times as fast. The pitch of clip also changes accordingly. I hope it won't get annoying",
                    "After the last dialog line, the box will close. Hope you like it!"

                }
            ;

        }

        private void Update()
        {
            if (Input.GetKeyDown(NextKey))
            {
                dialogBox.ShowDialog();
            }

            dialogBox.SpedUp = Input.GetKey(FastForwardKey);



        }
    }
}