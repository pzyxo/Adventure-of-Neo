using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
    private bool isMuted = false;
    public Button button;
    public Sprite pressedSprite;

    private Image buttonImage;
    private Sprite defaultSprite;

    private void Start()
    {
        buttonImage = button.GetComponent<Image>();
        defaultSprite = buttonImage.sprite;
    }

    private void Update() 
    {
        if(isMuted){
            buttonImage.sprite = pressedSprite;
        } else {
            buttonImage.sprite = defaultSprite;
        }
    }  
    
    public void ToggleMute()
    {
        isMuted = !isMuted;

        AudioListener.volume = isMuted ? 0f : 1f;

        Debug.Log("Sound muted: " + isMuted);
    }
}
