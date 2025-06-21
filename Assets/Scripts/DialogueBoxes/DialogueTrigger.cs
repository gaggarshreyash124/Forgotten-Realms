using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [System.Serializable]
    public class DialogueCharacter
    {
        public string name; // character names
        public Sprite icon; // character icon

    }

    [System.Serializable]
    public class DialogueLine
    {
        public DialogueCharacter character;
        [TextArea(3, 10)]
        public string line;

    }

    [System.Serializable]
    public class Dialogue
    {
        public List<DialogueLine> dialoguelines = new List<DialogueLine>();
    }

    public Dialogue dialogue;
}
