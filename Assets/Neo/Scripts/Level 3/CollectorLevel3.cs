using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorLevel3 : MonoBehaviour
{
    private float x;
    private float y;
    public float timeBtwDestroy = 2f;
    public float startTimeBtwDestroy = 2f;
    public int moneyCount = 10000;
    public int index;

    [SerializeField] private GameObject subwayPrompt;
    [SerializeField] private GameObject moneyPrompt;
    [SerializeField] private GameObject insufficientAlert;
    [SerializeField] private GameObject endGamePrompt;
    [SerializeField] private GameObject endGameCollider;
    [SerializeField] private GameObject endGameWays;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject closePanel;
    [SerializeField] private GameObject materiPanel;
    [SerializeField] private GameObject mainQuest;
    [SerializeField] private GameObject completedQuest;
    [SerializeField] private GameObject endGameGuide;

    [SerializeField] private GameObject[] mainQuestPanel;

    [SerializeField] private GameObject falseAlert;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI endGameGuideText;
    private PlayerLife pl;
    private Slideshow slide;

    private void Start()
    {
        pl = GetComponent<PlayerLife>();
        slide = materiPanel.GetComponent<Slideshow>();
    }
    private void Update()
    {
        moneyText.text = "Rp." + moneyCount;
        if (insufficientAlert.activeSelf || falseAlert.activeSelf)
        {
            timeBtwDestroy -= Time.deltaTime;
            if (timeBtwDestroy <= 0)
            {
                insufficientAlert.SetActive(false);
                falseAlert.SetActive(false);
                timeBtwDestroy = startTimeBtwDestroy;
            }

        }

        if (mainQuest.activeSelf)
        {
            mainQuestPanel[index].SetActive(true);
        }


        // mainQuestPanel[index];
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Subway 1"))
        {
            subwayPrompt.SetActive(true);
            x = -2;
            y = 7;
        }

        if (other.gameObject.CompareTag("Subway 2"))
        {
            subwayPrompt.SetActive(true);
            x = -9;
            y = 21;
        }

        if (other.gameObject.CompareTag("End Game"))
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        subwayPrompt.SetActive(false);
        interactButton.SetActive(false);

    }

    public void SubwayTeleport()
    {
        if (moneyCount >= 800)
        {
            moneyCount -= 800;
            transform.position = new Vector3(x, y, 0);
            subwayPrompt.SetActive(false);
        }
        else
        {
            insufficientAlert.SetActive(true);
        }

    }

    public void CancelTeleport()
    {
        subwayPrompt.SetActive(false);
    }

    public void RestoreLifes()
    {
        if (moneyCount >= 50000)
        {
            moneyCount -= 50000;
            pl.RestoreLifes();
        }
        else
        {
            insufficientAlert.SetActive(true);
        }
        moneyPrompt.SetActive(false);
    }

    public void CancelRestore()
    {
        moneyPrompt.SetActive(false);
    }

    public void interact()
    {
        endGamePrompt.SetActive(true);
    }
    public void EndGame()
    {
        if (moneyCount >= 1000000)
        {
            moneyCount -= 1000000;
            Debug.Log("Pembangunan dimulai");
            endGameCollider.SetActive(false);
            endGameWays.SetActive(true);
        }
        else
        {
            insufficientAlert.SetActive(true);
        }
        endGamePrompt.SetActive(false);
    }

    public void CancelEndGame()
    {
        endGamePrompt.SetActive(false);
    }

    public void ClosePanel()
    {
        closePanel.SetActive(false);
    }

    public void NextSlide()
    {
        slide.NextSlide();
    }

    public void OpenMainQuest()
    {
        mainQuest.SetActive(true);
    }
    public void TrueAnswer()
    {
        moneyCount += 100000;
        if (moneyCount >= 1000000)
        {
            endGameGuide.SetActive(true);
            endGameGuideText.text = "Uang sudah terkumpul, Pergilah ke bagian selatan kota dan bangunlah jalan menuju ForsakenVille";
        }
        Destroy(mainQuestPanel[index]);
        mainQuestPanel[index] = completedQuest;
        if (index < mainQuestPanel.Length - 1)
        {
            index++;
        }

    }

    public void FalseAnswer()
    {
        pl.ReduceLifes();
        falseAlert.SetActive(true);
    }

    public void NextQuestion()
    {
        mainQuestPanel[index].SetActive(false);
        if (index < mainQuestPanel.Length - 1)
        {
            index++;
        }

    }

    public void PrevQuestion()
    {
        mainQuestPanel[index].SetActive(false);
        if (index > 0)
        {
            index--;
        }

    }

    public void CloseMainQuest()
    {
        mainQuest.SetActive(false);
    }



}
