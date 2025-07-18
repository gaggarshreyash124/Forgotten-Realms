using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using static NewBehaviourScript;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public UnityEngine.UI.Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;
    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;

    public void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        animator.Play("show");
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialoguelines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));

    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");

    }

}
