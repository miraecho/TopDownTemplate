using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines; //Mark where dialogue ends
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

    public Dialoguechoice[] choices;
}

[System.Serializable]
public class Dialoguechoice 
{
    public int dialogueIndex; //Index of dialogueLines where choices appear
    public string[] choices; //Player's response options]
    public int[] nextDialogueIndexes; //Where choice leads to
}
