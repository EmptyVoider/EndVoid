using System;
using System.Collections;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dialogue
{
    public class DialogueBox : MonoBehaviour
    {
        public float CharactersPerSecond;
        public TextMeshProUGUI Textbox;
        public GameObject NextPrompt;
        public int CharactertsPerRow;//This is a bit complex to get an accurate measurement.
        public AudioSource SpeechAudio;
        public bool SpedUp { get; set; }
        public AudioClip[] Speech { get; set; }
        public bool HasMoreDialogue { get; set; }

        private int lineIndex; //index for which line we are showing
        private int characterIndex; //index for which line we are showing
        
        private string[] lines;
        private bool stillShowingLastLine;
        private char[] ALL_VOWLES = {'a','A', 'e', 'E', 'i', 'I', 'o', 'O','u', 'U'};
        private float origianlPitch;

        private void Awake()
        {
            origianlPitch = SpeechAudio.pitch;
        }

        public void SetDialogue(string[] lines)
        {
            this.lines = lines;
            lineIndex = 0;
            characterIndex = 0;
            HasMoreDialogue = lines.Length > 0;
        }

        public void ShowDialogue()
        {
            StartCoroutine(ShowNextLine());
        }

        private IEnumerator ShowNextLine()
        {
            if (stillShowingLastLine)
            {
                yield break;
            }

            PrepareToShowNewLine();
            var line = AddLineBreaks(lines[lineIndex]);
            while (Textbox.text.Length < line.Length)
            {
                characterIndex += 1;
                var shouldWaitBeforeNextCharacter = ShowDialogUpToCharacter(line);
                if (shouldWaitBeforeNextCharacter)
                {
                    yield return new WaitForSeconds(1 / CharactersSpeed());
                }

            }
            PrepareForNextLine();
        }

        private string AddLineBreaks(string line)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var insideTag = false;
            int charactersInThisLine = 0;
            int index = 0;
            foreach (var character in line)
            {
                insideTag = EscapeTags(character, insideTag, stringBuilder);
                if (!insideTag && character != '>')
                {
                    stringBuilder.Append(character);
                    charactersInThisLine += 1;
                    if (character == ' ' && ShouldBreakLine(line, index, charactersInThisLine))
                    {
                        stringBuilder.Append("\n");
                        charactersInThisLine = 0;
                    }
                }
                index++;
            }
            return stringBuilder.ToString();
        }

        /**
         * To support rich tags, we can't show the content of tags one character at a time
         * We also should not wait between this character and the next if we are inside a tag, because
         * to the player it looks like nothing is shown and there is a delay between the actual characters
         */
        private bool ShowDialogUpToCharacter(string line)
        {
            bool insideTag = false;
            StringBuilder stringBuilder = new StringBuilder();
            bool shouldWait = false;
            for (int i = 0; i < line.Length; i++)
            {
                var character = line[i];
                insideTag = EscapeTags(character, insideTag, stringBuilder);
                if (!insideTag && character != '>' && i <= characterIndex)
                {
                    stringBuilder.Append(character);
                    if (IsVowel(character))
                    {
                        PlayRandomSound();

                    }
                }

                //the delay between different characters should not trigger for characters inside tags
                if (i == characterIndex)
                {
                    shouldWait = !insideTag;
                }
            }

            Textbox.text = stringBuilder.ToString();
            return shouldWait;
        }

        private void PlayRandomSound()
        {
            AdjustPitch();
            if (SpeechAudio.isPlaying)
            {
                return;
            }
            PlayNewSound();
        }

        private void PlayNewSound()
        {
            var i = Random.Range(0, Speech.Length); //Random is exclusive in int for some reason
            SpeechAudio.clip = Speech[i];
            SpeechAudio.Play();
        }

        private void AdjustPitch()
        {
            if (SpedUp)
            {
                SpeechAudio.pitch = origianlPitch * 1.5f;
            }
            else
            {
                SpeechAudio.pitch = origianlPitch;
            }
        }

        private bool IsVowel(char character)
        {
            return ALL_VOWLES.Contains(character);
        }

        private bool ShouldBreakLine(string line, int index, int charactersInLine)
        {
            
            if (index >= line.Length - 1)
            {
                return false;//End of the line
            }
            var substring = line.Substring(index + 1);
            var endOfWord = substring.IndexOf(' ');
            if (endOfWord <= 0)
            {
                return false;
            }
            string nextWord = substring.Substring(0, endOfWord);
            var shouldBreakLine = charactersInLine + nextWord.Length >= this.CharactertsPerRow;
            return shouldBreakLine;

        }


        private static bool EscapeTags(char character, bool insideTag, StringBuilder sb)
        {
            if (character == '<')
            {
                insideTag = true;
            }

            if (insideTag)
            {
                sb.Append(character);
            }

            if (character == '>')
            {
                insideTag = false;
            }

            return insideTag;
        }


        private void PrepareToShowNewLine()
        {
            this.stillShowingLastLine = true;
            NextPrompt.SetActive(false);
            characterIndex = 0;
            Textbox.text = "";
            SpeechAudio.Play();
        }

        private void PrepareForNextLine()
        {
            stillShowingLastLine = false;
            NextPrompt.SetActive(true);
            lineIndex += 1;
            if (lineIndex >= lines.Length)
            {
                HasMoreDialogue = false;
            }
        }

        private float CharactersSpeed()
        {
            if (SpedUp)
            {
                return CharactersPerSecond * 3;//arbitrary 
            }
            else
            {

                return CharactersPerSecond;
            }
        }

    }
    
}
