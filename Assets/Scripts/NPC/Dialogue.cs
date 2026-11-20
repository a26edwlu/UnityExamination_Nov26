using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textBox;
    [SerializeField] private Button nextButton;
    [SerializeField] List<string> dialogue; 
    [SerializeField] List<string> altDialogueText;

    [SerializeField] private UnityEvent onStartDialogue;
    [SerializeField] private UnityEvent onEndDialogue;

    private int currentIndex = -1; 
    
    private bool altDialogue = false;


    public void NextDialogue()
    {
        // If dialogue wasn't started: run the onStartDialogue-event, and add this dialogue to the Next-Button
        if (currentIndex < 0)
        {
            onStartDialogue?.Invoke();
            nextButton?.onClick.AddListener(NextDialogue);
        }
        
        // Move to the next item in the list of dialogue-lines
        currentIndex++;
        // If we're not at the end of the list yet: update text in text-box 
        if (!altDialogue)
        {
            if (currentIndex < dialogue.Count)
            {
                textBox.text = dialogue[currentIndex];
            }
            else
            {
                EndDialogue();
            }
            
        } 
        else if (altDialogue)
        {
            if (currentIndex < altDialogueText.Count)
            {
                textBox.text = altDialogueText[currentIndex];
            }
            else
            {
                EndDialogue();
            }
        }
       
      
    }

    public void AlternativeDialogueSwitch()
    {
        altDialogue = true;
    }

    private void EndDialogue()
    {
        textBox.text = "";
        onEndDialogue?.Invoke();
        currentIndex = -1;
        nextButton?.onClick.RemoveListener(NextDialogue);
    }
}