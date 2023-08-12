using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slideshow : MonoBehaviour
{
    [SerializeField] private Sprite[] slideShow;
    [SerializeField] private GameObject materiPanel;
    [SerializeField] private GameObject closePanel;

    public Image materiImage;
    public int index = 0;
    public int startIndex = 0;
    public int endIndex = 11;

    // Start is called before the first frame update
    void Start()
    {
        materiImage = materiPanel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        materiImage.sprite = slideShow[index];
        if (index > endIndex)
        {
            index = startIndex;
        }
        
    }

    public void NextSlide()
    {
        
        if(endIndex - startIndex != 0 && index < endIndex)
        {
            index++;
        }
        else
        {
            index = startIndex;
        }
        
    }

    public void ChangeIndex(int x, int y)
    {
        startIndex = x;
        endIndex = y;
        index = startIndex;
    }

    public void ClosePanel()
    {
        closePanel.SetActive(false);
    }
}
