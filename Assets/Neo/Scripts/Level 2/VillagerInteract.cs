using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillagerInteract : MonoBehaviour
{
    [SerializeField] private GameObject NPCInteract;
    [SerializeField] private string newInteractText;
    [SerializeField] private string newNPCName;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI NPCName;

    
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            interactText.text = newInteractText;
            NPCName.text = newNPCName;
            NPCInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(NPCInteract.activeSelf)
        {
            NPCInteract.SetActive(false);
        }
        
    }
}
