using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideAlert : MonoBehaviour
{
    [SerializeField] private GameObject guideAlert;
    [SerializeField] private string newGuideText;
    [SerializeField] private TextMeshProUGUI guideText;
    
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            guideText.text = newGuideText;
            guideAlert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(guideAlert.activeSelf)
        {
            guideAlert.SetActive(false);
        }
        
    }
}
