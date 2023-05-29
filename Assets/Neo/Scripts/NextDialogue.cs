using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogue : MonoBehaviour
{
    private Dialogue dialogue;

    private void Update() {
        bool isDialogue = Dialogue.popped;
        if(isDialogue)
        {
            Debug.Log(isDialogue);
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }

    public void OnClickAction()
    {
        dialogue.OnClickAction();
        Debug.Log("success");
    }
}
