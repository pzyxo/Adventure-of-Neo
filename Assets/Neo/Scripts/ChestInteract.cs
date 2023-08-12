using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestInteract : MonoBehaviour
{
    private Animator anim;
    public bool isChestOpen = false;
    private float variableValue = 2f;
    private float timeBtwDestroy = 2f;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private GameObject chestObject;
    
    [SerializeField] private GameObject[] answerButton;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI trueAnswerText;
    [SerializeField] private TextMeshProUGUI false1Text;
    [SerializeField] private TextMeshProUGUI false2Text;
    [SerializeField] private string question;
    [SerializeField] private string trueAnswer;
    [SerializeField] private string falseAnswer1;
    [SerializeField] private string falseAnswer2;
    [SerializeField] private AudioSource chestOpenSound;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        isChestOpen = false;
    }

    private void Update() {
        
        if(isChestOpen == true)
        {
            anim.SetBool("opening", true);
            timeBtwDestroy -= Time.deltaTime;
            if(timeBtwDestroy <= 0)
            {
                chestObject.SetActive(false);
            }
        } 
        if (alertPanel.activeSelf)
        {
            variableValue -= Time.deltaTime;
            if(variableValue <= 0)
            {
                alertPanel.SetActive(false);
                variableValue = 2f;
            }
        }
    }

    public void ChestOpening()
    {
        if(isChestOpen == false)
        {
            Chest.ChestOpened();
            chestOpenSound.Play();
            isChestOpen = true;
            
        }
        variableValue = 2f;
        alertPanel.SetActive(true);
        Debug.Log(isChestOpen);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            questionText.text = question;
            trueAnswerText.text = trueAnswer;
            false1Text.text = falseAnswer1;
            false2Text.text = falseAnswer2;
        }
    }

    // private void ChestOpened()
    // {
    //     questionText.text = "Chest sudah dibuka";
    //     trueAnswer.SetActive(false);
    //     falseAnswer1.SetActive(false);
    //     falseAnswer2.SetActive(false);
    // }
}
