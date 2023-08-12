using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSide : MonoBehaviour
{
    [SerializeField] private int forestSide;
    [SerializeField] private GameObject[] MainQuestPanel;
     // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        MainQuestPanel[forestSide].SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            MainQuestPanel[forestSide].SetActive(true);
        }
    }
}
