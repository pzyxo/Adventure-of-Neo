using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingScreen : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    //gameobject jangan lupa diinisiasi!!
    public GameObject dialogueBox;

    private int index;

    
    void Start()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                textComponent.text = lines[index];
                StopAllCoroutines();
            }
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
            dialogueBox.SetActive(false);
        }
    }

}
