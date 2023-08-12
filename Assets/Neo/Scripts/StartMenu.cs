using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private float decreaseRate = 1f;
    private float variableValue = 5f;

    [SerializeField] private GameObject firstImage;
    [SerializeField] private GameObject learnPanel;
    [SerializeField] private AudioSource clickedSound;

    private void Update() 
    {
        variableValue -= decreaseRate * Time.deltaTime;

        if(variableValue <= 0f || Input.GetMouseButtonDown(0))
        {
            firstImage.SetActive(false);
        }
    }
    
    public void StartGame()
    {
        clickedSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LearnMath()
    {
        learnPanel.SetActive(true);
    }
}
