using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Dialogue : MonoBehaviour
{
    private bool playerInRange = false;
    public bool Dialoguing;
    private int lineNumber;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField, TextArea(4, 10)] private string[] Dialogues;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI DialogueText;
    private void Start()
    {
        dialoguePanel.SetActive(false);
    }
    void Update()
    {
        if (playerInRange && Input.GetKeyUp(KeyCode.H))
        {
            if (!Dialoguing)
            {
                StartDialogue();
            }else if(DialogueText.text == Dialogues[lineNumber])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = Dialogues[lineNumber];
            }
        }
    }
    private void StartDialogue()
    {
        Dialoguing = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineNumber = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogue()
    {
        lineNumber++;
        if (lineNumber < Dialogues.Length)
        {
            StartCoroutine(ShowLine());
        }else
        {
            Dialoguing=false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true) ;
        }
    }

    private IEnumerator ShowLine()
    {
        DialogueText.text=string.Empty;
        foreach (char ch in Dialogues[lineNumber]) { 
        DialogueText.text += ch;    
            yield return new WaitForSeconds(0.01f);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            dialogueMark.SetActive(true);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueMark.SetActive(false);
            dialoguePanel.SetActive(false);
           
           
        }
        
    }
   
    
}
