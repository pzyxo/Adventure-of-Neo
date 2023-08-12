using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMaterial : MonoBehaviour
{
    public int x;
    public int y;
    private int index;
    [SerializeField] private Sprite[] slideShow;
    [SerializeField] private GameObject materiPanel;
    private Image materiImage;
    private Slideshow slide;

    void Start()
    {
        slide = materiPanel.GetComponent<Slideshow>();
        materiImage = materiPanel.GetComponent<Image>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            slide.ChangeIndex(x,y);
        }
    }
}
