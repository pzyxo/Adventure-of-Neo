using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject questPanel;
    [SerializeField] private string newQuestTitle;
    [SerializeField] private string newQuestText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI questText;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            titleText.text = newQuestTitle;
            questText.text = newQuestText;
            questPanel.SetActive(true);
        }
    }
}
