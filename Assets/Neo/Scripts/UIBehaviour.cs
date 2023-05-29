using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    
    public GameObject joystickButton;
    public GameObject sprintButton;


    public void HideButton()
    {
        Debug.Log("sukses");
        joystickButton.SetActive(false);
        sprintButton.SetActive(false);
    }

    public void ShowButton()
    {
        joystickButton.SetActive(true);
        sprintButton.SetActive(true);
    }
}
