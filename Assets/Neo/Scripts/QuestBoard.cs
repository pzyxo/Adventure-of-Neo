using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBoard : MonoBehaviour
{
    [SerializeField] private GameObject questBoard;

    private void Update() {
        if(questBoard.activeSelf)
        {
            if(Input.GetMouseButtonDown(0))
            {
                questBoard.SetActive(false);
            }
        }
    }
    
    public void OnClickAction()
    {
        if(!questBoard.activeSelf){
            questBoard.SetActive(true);
        }
    }
}
