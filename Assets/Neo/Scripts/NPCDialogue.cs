using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject boxMessage;
    public GameObject buttonQuest;
    public GameObject buttonDialogue;
    
    bool player_detection = false;

    private void Update() {
        if(player_detection && Input.GetKeyDown(KeyCode.F)){
            boxMessage.SetActive(true);
            buttonDialogue.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {  
    
        if (other.gameObject.tag == "Player")
        {
            // buttonDialogue.SetActive(true);   
            buttonQuest.SetActive(true);
            player_detection = true;
            
            // display the text in a pop-up window
        }
    }

    private void OnTriggerExit2D(Collider2D other) {  
    
        if (other.gameObject.tag == "Player")
        {
            buttonQuest.SetActive(false);
            player_detection = false;
            // display the text in a pop-up window
        }
    }

    public void OnClickAction()
    {
        if(player_detection){
            buttonDialogue.SetActive(true);
            boxMessage.SetActive(true);
            buttonQuest.SetActive(false);
        }
    }

}
