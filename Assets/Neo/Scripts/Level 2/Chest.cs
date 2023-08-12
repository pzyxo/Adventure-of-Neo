using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    public static int chests;
    private bool isAccepted = false;
    private bool isQuestClearPrasyarat = false;
    private bool isQuestClearFirst = false;
    private bool isQuestClearSecond = false;
    private bool isQuestClearThird = false;
    private float timeBtwDestroy = 2;
    private float startTimeBtwDestroy = 2;

    [SerializeField] private GameObject[] triggerQuest;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private TextMeshProUGUI chestsCount;
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private TextMeshProUGUI questTitleText;

    CollectorLevel2 cl2;

    // public static Dialogue dialogue;

    private void Start()
    {
        cl2 = GameObject.Find("UnitRoot").GetComponent<CollectorLevel2>();
    }

    void Update()
    {
             
        chestsCount.text = "" + chests + "/6";

            if (chests >= 6)
            {
                timeBtwDestroy -= Time.deltaTime;
                if (timeBtwDestroy <= 0)
                {
                    questPanel.SetActive(false);
                    triggerQuest[0].SetActive(false);
                }
                if (questPanel.activeSelf)
                {
                    questText.text = "Quest Completed";
                    isQuestClearPrasyarat = true;
                }
                else
                {
                    timeBtwDestroy = startTimeBtwDestroy;
                }

            }

        if (isQuestClearPrasyarat)
        {

            questPanel.SetActive(true);

            if (questPanel.activeSelf)
            {
                questTitleText.text = "Quest Pertama";
                questText.text = "1. Carilah coin yang hilang dari gerbang\n2. Selesaikan mekanisme dengan mengisi coin yang hilang dengan coin yang benar";
            }
            if (cl2.is1stSwitched)
            {
                timeBtwDestroy -= Time.deltaTime;
                if (timeBtwDestroy <= 0)
                {
                    questPanel.SetActive(false);
                    triggerQuest[0].SetActive(false);
                }
                if (questPanel.activeSelf)
                {
                    questText.text = "Quest Completed";
                    isQuestClearFirst = true;
                }
                else
                {
                    timeBtwDestroy = startTimeBtwDestroy;
                }
            }
        }

        if (isQuestClearFirst)
        {

            questPanel.SetActive(true);

            if (questPanel.activeSelf)
            {
                questTitleText.text = "Quest Kedua";
                questText.text = "1. Masukkan coin tanda hubung yang benar ke dalam lubang coin\n 2. nyalakan switch";
            }
            if (cl2.is2ndSwitched)
            {
                timeBtwDestroy -= Time.deltaTime;
                if (timeBtwDestroy <= 0)
                {
                    questPanel.SetActive(false);
                    triggerQuest[0].SetActive(false);
                }
                if (questPanel.activeSelf)
                {
                    questText.text = "Quest Completed";
                    isQuestClearSecond = true;
                }
                else
                {
                    timeBtwDestroy = startTimeBtwDestroy;
                }
            }
        }

        if (isQuestClearSecond)
        {

            questPanel.SetActive(true);

            if (questPanel.activeSelf)
            {
                questTitleText.text = "Quest Ketiga";
                questText.text = "1. Urutkan coin dari yang terkecil hingga yang terbesar\n2. Nyalakan switch";
            }
            if (cl2.is3rdSwitched)
            {
                timeBtwDestroy -= Time.deltaTime;
                if (timeBtwDestroy <= 0)
                {
                    questPanel.SetActive(false);
                    triggerQuest[0].SetActive(false);
                }
                if (questPanel.activeSelf)
                {
                    questText.text = "Quest Completed";
                    isQuestClearThird = true;
                }
                else
                {
                    timeBtwDestroy = startTimeBtwDestroy;
                }
            }
        }

        if(isQuestClearThird)
        {
            questPanel.SetActive(true);
            questTitleText.text = "Quest Completed";
            questText.text = "Terima kasih Neo\n Silahkan lanjutkan perjalananmu";
        }

    }

    public static void ChestOpened()
    {
        chests++;
        Debug.Log("Chest Opened" + chests);
    }

    public static void GetIsAccepted()
    {
        // isAccepted1 = true;
    }
}
