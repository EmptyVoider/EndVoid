using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class Dialogue
    {
        public string npcName;

        [TextArea(3, 25)]
        public string[] sentences;

        public AudioClip[] sentenceSound;
    }
}
