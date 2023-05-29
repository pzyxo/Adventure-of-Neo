using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBoard : MonoBehaviour
{
    [SerializeField] private GameObject questBoard;
    [SerializeField] private TextMeshProUGUI buttonText;

    public void OnClickAction()
    {
        if(!questBoard.activeSelf){
            questBoard.SetActive(true);
            buttonText.text = "Hide";
        } else {
            questBoard.SetActive(false);
            buttonText.text = "Show";
        }
    }
}
