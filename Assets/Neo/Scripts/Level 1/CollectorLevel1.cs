using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectorLevel1 : MonoBehaviour
{
    private bool forestTeleport = false;
    private bool[] coins;
    private bool isForest1 = false;
    private bool isForest2 = false;
    private int index;
    private int coinsCollected = 0;
    private float timeBtwDestroy = 2f;

    private Rigidbody2D rb;
    private Animator anim;

    public PlayerLife pl;

    [SerializeField] private GameObject[] MainQuestPanel; // panel untuk quest utama
    [SerializeField] private GameObject[] CoinsCollected;  // kumpulan coins di bagian quest panel utama
    [SerializeField] private GameObject Coins2QuestPanel; // panel quest khusus untuk coin 2
    [SerializeField] private GameObject[] CoinsLists; // semua coin yang ada di game
    [SerializeField] private GameObject[] CoinsPrompts; // prompt tiap coin yang diambil
    [SerializeField] private GameObject falseAnswerAlert; // jika jawaban salah

    [SerializeField] private GameObject endGate; // untuk berpindah ke next level
    [SerializeField] private GameObject gate; // penghalang di level 1
    [SerializeField] private GameObject invisibleWall; // penghalang setelah mengambil coin final level 1
    [SerializeField] private GameObject ForestBlocks; // penghalang di level 2
    [SerializeField] private GameObject FinalCoin2Quest; // quest forest 2
    [SerializeField] private GameObject ForestTeleportedQuest; // Ini untuk alert mendapat quest baru
    [SerializeField] private GameObject[] AnswerCoins;
    [SerializeField] private GameObject[] arrow;
    [SerializeField] private AudioSource collectedSoundEffect;
    [SerializeField] private TextMeshProUGUI coinsText;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pl = GetComponent<PlayerLife>();
        coins = new bool[9];

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i] = false;
        }
    }

    private void Update()
    {
        if (coins[0])
        {
            CoinsCollected[0].SetActive(true);
            arrow[1].SetActive(false);
        }
        if (coins[1])
        {
            Destroy(Coins2QuestPanel);
            CoinsCollected[1].SetActive(true);
            arrow[2].SetActive(false);
        }

        if (coins[2])
        {
            arrow[3].SetActive(false);
            CoinsCollected[2].SetActive(true);

        }

        if (coins[0] && coins[1] && coins[2])
        {
            gate.SetActive(false);
            arrow[4].SetActive(true);
        }

        if (coins[3])
        {
            invisibleWall.SetActive(true);
            endGate.SetActive(true);
        }

        if (coins[4] && coins[5] && coins[6] && coins[7])
        {
            ForestBlocks.SetActive(false);
            FinalCoin2Quest.SetActive(true);
        }

        if(forestTeleport)
        {
            ForestTeleportedQuest.SetActive(true);
            timeBtwDestroy -= Time.deltaTime;
            if(timeBtwDestroy <= 0)
            {
                ForestTeleportedQuest.SetActive(false);
                forestTeleport = false;
            }
            
        }

        coinsText.text = "" + coinsCollected + "/7";

        if(isForest1)
        {
            MainQuestPanel[0].SetActive(true);
            MainQuestPanel[1].SetActive(false);
        } else {
            MainQuestPanel[0].SetActive(false);
            MainQuestPanel[1].SetActive(true);
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins 1/3"))
        {
            pickupButton.SetActive(true);
            index = 0;
            // firstCoin = true;

        }

        if (collision.gameObject.CompareTag("Coins 2/4"))
        {
            pickupButton.SetActive(true);
            index = 1;
            // secondCoin = true;
        }

        if (collision.gameObject.CompareTag("Coins 2/3"))
        {
            pickupButton.SetActive(true);
            index = 2;
            // thirdCoin = true;
        }

        if (collision.gameObject.CompareTag("Final Answer"))
        {
            index = 3;
            CoinsPrompts[3].SetActive(false);
            collectedSoundEffect.Play();
            coins[index] = true;
            // finalCoin = true;
        }

        if (collision.gameObject.CompareTag("Level 1 Trigger"))
        {
            index = 3;
            CoinsPrompts[index].SetActive(true);
        }

        if (collision.gameObject.CompareTag("Coin a"))
        {
            pickupButton.SetActive(true);
            index = 4;
            // thirdCoin = true;
        }

        if (collision.gameObject.CompareTag("Coin b"))
        {
            pickupButton.SetActive(true);
            index = 5;
            // thirdCoin = true;
        }

        if (collision.gameObject.CompareTag("Coin c"))
        {
            pickupButton.SetActive(true);
            index = 6;
            // thirdCoin = true;
        }

        if (collision.gameObject.CompareTag("Coin d"))
        {
            pickupButton.SetActive(true);
            index = 7;
            // thirdCoin = true;
        }

        if (collision.gameObject.CompareTag("Wrong Answer"))
        {
            index = 8;
            CoinsPrompts[index].SetActive(true);
        }

        if (collision.gameObject.CompareTag("NPC Dialog trigger"))
        {
            CoinsPrompts[9].SetActive(true);
        }

        if (collision.gameObject.CompareTag("Forest 1"))
        {
            pl.changePos(25, 19);
            pl.TeleportPosition();
            forestTeleport = true;
            timeBtwDestroy = 2f;
        }

        if (collision.gameObject.CompareTag("Forest 2"))
        {
            pl.changePos(-30, -13);
            pl.TeleportPosition();
        }

        if (collision.gameObject.CompareTag("Final 2 Answer"))
        {
            index = 11;
            for (int i = 0; i < AnswerCoins.Length; i++)
            {
                AnswerCoins[i].SetActive(false);
            }
            FinalCoin2Quest.SetActive(false);
            collectedSoundEffect.Play();
        }

        if(collision.gameObject.CompareTag("Switch 1"))
        {
            isForest1 = true;
            isForest2 = false;
        }

        if(collision.gameObject.CompareTag("Switch 2"))
        {
            isForest2 = true;
            isForest1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickupButton.SetActive(false);

        if (collision.gameObject.CompareTag("NPC Dialog trigger"))
        {
            CoinsPrompts[9].SetActive(false);
        }
    }

    public void PickCoinPrompted()
    {
        HideButton();
        CoinsPrompts[index].SetActive(true);
    }

    public void TrueAnswer(int i)
    {
        CoinsLists[i].SetActive(true);
        Destroy(CoinsLists[i]);
        CoinsPrompts[i].SetActive(false);
        collectedSoundEffect.Play();
        coins[i] = true;
        ShowButton();
        coinsCollected++;
    }

    public void FalseAnswer(int i)
    {
        Debug.Log("false");
        CoinsPrompts[i].SetActive(false);
        ShowButton();
        rb.bodyType = RigidbodyType2D.Static;
        falseAnswerAlert.SetActive(true);
        pl.ReduceLifes();
    }




    // UI Behaviour, little mess up with the positioning but i guess it's okay
    public GameObject joystickButton;
    public GameObject sprintButton;
    public GameObject attackButton;
    public GameObject pickupButton;


    public void HideButton()
    {
        Debug.Log("hide button");
        rb.bodyType = RigidbodyType2D.Static;
        joystickButton.SetActive(false);
        sprintButton.SetActive(false);
        attackButton.SetActive(false);
        pickupButton.SetActive(false);
    }

    public void ShowButton()
    {
        Debug.Log("show button");
        rb.bodyType = RigidbodyType2D.Dynamic;
        joystickButton.SetActive(true);
        sprintButton.SetActive(true);
        attackButton.SetActive(true);
    }

    public void RestartLevel()
    {
        transform.position = new Vector3(-30, 19, 0);
        anim.SetBool("death", false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        ShowButton();
        CoinsPrompts[index].SetActive(false);
        falseAnswerAlert.SetActive(false);
    }
}
