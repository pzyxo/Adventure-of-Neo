using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorLevel2 : MonoBehaviour
{
    public bool is1stSwitched = false;
    public bool is2ndSwitched = false;
    public bool is3rdSwitched = false;
    public bool is1stCompleted = false;
    public bool is2ndCompleted = false;
    public bool is3rdCompleted1 = false;
    public bool is3rdCompleted2 = false;
    public bool is3rdCompleted3 = false;
    private bool isCoin1Found = false;
    private int index;
    
    public int chestCollected = 0;
    public Transform interactPos = null;
    public LayerMask whatIsChest;
    public float interactRange;

    private Rigidbody2D rb; 
    private Animator anim;
    private PlayerLife pl;

    [SerializeField] private GameObject[] interactPrompt;
    [SerializeField] private GameObject[] mechanismPanel;
    [SerializeField] private GameObject swingAlert;
    [SerializeField] private GameObject bridge;
    [SerializeField] private GameObject missingAlert;
    [SerializeField] private GameObject falseAlert;
    [SerializeField] private GameObject CoinAnswer1st;
    [SerializeField] private GameObject CoinAnswer2nd;
    [SerializeField] private GameObject CoinAnswer3rd1;
    [SerializeField] private GameObject CoinAnswer3rd2;
    [SerializeField] private GameObject CoinAnswer3rd3;
    [SerializeField] private GameObject MissingCoin;
    [SerializeField] private GameObject ChestIncompletedGates;
    [SerializeField] private GameObject CoinCompletedGates;
    [SerializeField] private AudioSource collectedSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pl = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    private void Update()
    {
        chestCollected = Chest.chests;
        is1stSwitched = Switch1.isSwitchOn;
        is2ndSwitched = Switch2.isSwitchOn;
        is3rdSwitched = Switch3.isSwitchOn;
        // Debug.Log(chestCollected);
        if(isCoin1Found)
        {
            pl.changePos(0,0);
            ChestIncompletedGates.SetActive(false);
            CoinCompletedGates.SetActive(true);
        }

        if(chestCollected >= 6)
        {
            if(MissingCoin != null)
            {
                MissingCoin.SetActive(true);
            }
            
            if(is1stSwitched && is2ndSwitched && is3rdSwitched)
            {
                Gates.OpeningGate();
                bridge.SetActive(true);
            }
            
        }

        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Switch 1"))
        {
            index = 0;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("Switch 2"))
        {
            index = 1;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("Switch 3"))
        {
            index = 2;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("Chest"))
        {
            index = 3;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("Missing Coin 1"))
        {
            index = 4;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("1st Mechanism"))
        {
            if(isCoin1Found)
            {
                index = 5;
                pickupButton.SetActive(true);
            } else {
                missingAlert.SetActive(true);
            }
            
        }
        
        if(other.gameObject.CompareTag("2nd Mechanism"))
        {
            index = 6;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("3rd Mechanism 1"))
        {
            index = 7;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("3rd Mechanism 2"))
        {
            index = 8;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("3rd Mechanism 3"))
        {
            index = 9;
            pickupButton.SetActive(true);
        }

        if(other.gameObject.CompareTag("Swing Alert"))
        {
            swingAlert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        pickupButton.SetActive(false);

        if(missingAlert.activeSelf)
        {
            missingAlert.SetActive(false);
        }

        if(swingAlert.activeSelf)
        {
            swingAlert.SetActive(false);
        }
    }


    public void InteractButtonAction()
    {
        HideButton();
        interactPrompt[index].SetActive(true);
    }

    // membuka chest
    public void OpenChest()
    {
        Collider2D[] openChest = Physics2D.OverlapCircleAll(interactPos.position, interactRange, whatIsChest);
            for (int i = 0; i < openChest.Length; i++)
            {
                openChest[i].GetComponent<ChestInteract>().ChestOpening();
            }
        ShowButton();
    }

    //tombol menyalakan switch
    public void Turn1stSwitchOn()
    {
        if(is1stCompleted)
        {
            Switch1.SwitchOn();
            Moving1stWall.MoveWall();
        }
        
        ShowButton();
    }

    public void Turn2ndSwitchOn()
    {
        if(is2ndCompleted)
        {
            Switch2.SwitchOn();
            Moving2ndWall.MoveWall();
        }
        
        ShowButton();
    }

    public void Turn3rdSwitchOn()
    {
        if(is3rdCompleted1 && is3rdCompleted2 && is3rdCompleted3)
        {
            Switch3.SwitchOn();
            Moving3rdWall.MoveWall();
        }

        ShowButton();
    }

    // tombol mengambil coin benar
    public void PickCoin()
    {
        isCoin1Found = true;
        collectedSoundEffect.Play();
        Destroy(MissingCoin);
        ShowButton();
    }

    // tombol jawaban salah
    public void FalseAnswer()
    {
        falseAlert.SetActive(true);
    }

    public void AcceptRestart()
    {
        pl.RestartLevel();
        ShowButton();
        falseAlert.SetActive(false);
    }

    // tombol mechanism pertama
    public void FirstTrueAnswer()
    {
        is1stCompleted = true;
        CoinAnswer1st.SetActive(true);
        ShowButton();
    }

    // tombol mechanism kedua
    public void SecondTrueAnswer()
    {
        is2ndCompleted = true;
        CoinAnswer2nd.SetActive(true);
        ShowButton();
    }

    // tombol mechanism ketiga
    public void ThirdTrueAnswer1()
    {
        is3rdCompleted1 = true;
        CoinAnswer3rd1.SetActive(true);
        ShowButton();
    }

    public void ThirdTrueAnswer2()
    {
        is3rdCompleted2 = true;
        CoinAnswer3rd2.SetActive(true);
        ShowButton();
    }

    public void ThirdTrueAnswer3()
    {
        is3rdCompleted3 = true;
        CoinAnswer3rd3.SetActive(true);
        ShowButton();
    }

    // close prompt
    public void CancelInterract()
    {
        ShowButton();
    }
    
    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactPos.position, interactRange);
    }


    // please don't rewrite or modified any of these scripts, cc : pzyxo
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
        if(interactPrompt[index].activeSelf){interactPrompt[index].SetActive(false);}
        joystickButton.SetActive(true);
        sprintButton.SetActive(true);
        attackButton.SetActive(true);
    }

    public void RestartLevel()
    {
        transform.position = new Vector3(-30,19,0);
        anim.SetBool("death", false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        ShowButton();
        interactPrompt[index].SetActive(false);
    }
}
