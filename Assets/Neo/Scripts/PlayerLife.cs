using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int life = 5;

    [SerializeField] private int posX = -30;
    [SerializeField] private int posY = 19;

    [SerializeField] private TextMeshProUGUI lifeCount;
    [SerializeField] private GameObject edgeCrossedText;
    [SerializeField] private GameObject trapHitText;
    [SerializeField] private GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        lifeCount.text = "" + life;
        if(life <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Traps"))
        {
            Die();
        }

        if(other.gameObject.CompareTag("Edge"))
        {
            IsEdgeCrossed();
        }  
    }

    private void Die()
    {
        
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        trapHitText.SetActive(true);
    }

    public void RestartLevel()
    {
        life--;
        trapHitText.SetActive(false);
        transform.position = new Vector3(posX,posY,0);
        anim.SetTrigger("respawn");
        rb.bodyType = RigidbodyType2D.Dynamic;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void IsEdgeCrossed()
    {
        rb.bodyType = RigidbodyType2D.Static;
        edgeCrossedText.SetActive(true);
    }

    public void CloseWarningPopUp()
    {
        edgeCrossedText.SetActive(false);
        transform.position = new Vector3(posX,posY,0);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void RestoreLifes()
    {
        life = 5;
    }

    public void ReduceLifes()
    {
        life--;
    }

    public void changePos(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public void TeleportPosition()
    {
        transform.position = new Vector3(posX,posY,0);
    }
}
