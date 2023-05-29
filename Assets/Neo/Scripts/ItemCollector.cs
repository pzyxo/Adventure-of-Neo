using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private int max_coins = 16;
    [SerializeField] private int max_npcs = 6;
        
    [SerializeField] private TextMeshProUGUI collected;
    [SerializeField] private TextMeshProUGUI talked;
    [SerializeField] private TextMeshProUGUI completed;

    [SerializeField] private GameObject endGate;
    [SerializeField] private AudioSource collectedSoundEffect;

    private void Update() 
    {
        int npcs = Dialogue.talked;
        talked.text = "Dialogue : " + npcs + "/" + max_npcs;
        collected.text = "Coins : " + coins + "/" + max_coins;

        if(coins >= max_coins)
        {
            collected.text = "<s>Coins : Done</s>";
        }

        if(npcs >= max_npcs)
        {
            talked.text = "<s>Dialogue : Done</s>";
        }

        if(coins >= max_coins && npcs >= max_npcs)
        {
            completed.text = "Completed! \n Find Way Out!";
            endGate.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            collectedSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
        }
    }
}
