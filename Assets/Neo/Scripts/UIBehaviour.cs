using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    
    public GameObject welcomeMessage;
    public static int level;
    private float variableValue = 2f;
    private float decreaseRate = 1f;

    private void Update() {
        level = SceneManager.GetActiveScene().buildIndex;

        variableValue -= decreaseRate * Time.deltaTime;

        if(welcomeMessage)
        {
            if(variableValue <= 0)
            {
                welcomeMessage.SetActive(false);
            }
        }
        
    }
}
