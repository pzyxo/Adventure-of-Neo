using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI answerComponent;
    public string[] lines;
    public string[] answer;
    public float textSpeed;
    public static int talked;
    public static bool popped;

    //gameobject jangan lupa diinisiasi!!
    public GameObject dialogueButton;
    public GameObject dialogueBox;
    public GameObject buttonQuest;
    public GameObject joystickButton;
    public GameObject sprintButton;

    private int index;

    
    void Start()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update() {
        if(dialogueBox.activeSelf)
        {
            popped = true;
            
            HideButton();
            dialogueButton.SetActive(true);
            AnswerDialogue();

        }
        else 
        {
            popped = false;
            dialogueBox.SetActive(false);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            
        }
    }

    private void AnswerDialogue()
    {
        answerComponent.text = answer[index];
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueButton.SetActive(false);
            dialogueBox.SetActive(false);
            ShowButton();
            buttonQuest.SetActive(true);
        }
    }

    public void OnClickAction()
    {
        if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                textComponent.text = lines[index];
                StopAllCoroutines();
                talked++;
            }
    }

    public void HideButton()
    {
        joystickButton.SetActive(false);
        sprintButton.SetActive(false);
    }

    public void ShowButton()
    {
        joystickButton.SetActive(true);
        sprintButton.SetActive(true);
    }
}
