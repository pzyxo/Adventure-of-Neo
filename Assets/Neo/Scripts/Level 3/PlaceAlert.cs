using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceAlert : MonoBehaviour
{
    [SerializeField] private string placeName;
    [SerializeField] private GameObject panelAlert;
    [SerializeField] private TextMeshProUGUI panelText;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            panelText.text = placeName;
            panelAlert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        panelAlert.SetActive(false);
    }
}
