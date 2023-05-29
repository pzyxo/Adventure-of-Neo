using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectorLevel1 : MonoBehaviour
{
    private bool firstCoin;
    private bool secondCoin;
    private bool thirdCoin;
    private string answer;
        
    [SerializeField] private GameObject Coins1Collected;
    [SerializeField] private GameObject Coins2Collected;
    [SerializeField] private GameObject Coins3Collected;

    [SerializeField] private GameObject endGate;
    [SerializeField] private GameObject gate;
    [SerializeField] private AudioSource collectedSoundEffect;

    private void Update() 
    {
        if(firstCoin && secondCoin && thirdCoin)
        {
            // if(answer == "3/2" | answer == "18/12" | answer == "9/6" | answer == "6/4")
            // {
                gate.SetActive(false);
            // }
            
        }
    }

    public void GetSAnswer(string s){
        answer = s;
        Debug.Log(answer);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Coins 1/3"))
        {
            collectedSoundEffect.Play();
            Destroy(collision.gameObject);
            Coins1Collected.SetActive(true);
            firstCoin = true;

        }

        if (collision.gameObject.CompareTag("Coins 2/4"))
        {
            collectedSoundEffect.Play();
            Destroy(collision.gameObject);
            Coins2Collected.SetActive(true);
            secondCoin = true;
        }

        if (collision.gameObject.CompareTag("Coins 2/3"))
        {
            collectedSoundEffect.Play();
            Destroy(collision.gameObject);
            Coins3Collected.SetActive(true);
            thirdCoin = true;
        }
    }
}
