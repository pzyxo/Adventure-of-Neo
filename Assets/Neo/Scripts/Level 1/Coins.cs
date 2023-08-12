using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private GameObject coinsA;
    [SerializeField] private TextMeshProUGUI pointsCount;
    [SerializeField] private TextMeshProUGUI panelText;
    // [SerializeField] private GameObject coinsB;
    // [SerializeField] private GameObject coinsC;

    public static int points;

    
    void Update()
    {
        if(coinsA)
        {
            if(points >= 10)
            {
                coinsA.SetActive(true);
                // questPanel.SetActive(false);
                // Destroy(questPanel);
                panelText.text = "Semua tikus sudah dibasmi, ambil coin di dekat Pak Tani";
            }
        }

        pointsCount.text = "" + points + "/10";
    }

    public static void EnemySlayed()
    {
        points++;
        Debug.Log("Enemy Slayed");
    }
}
