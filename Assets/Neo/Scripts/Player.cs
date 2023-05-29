using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Vector2 moveDelta;
    public float moveSpeed = 5f;
    public VariableJoystick joystick;
    private RaycastHit2D hit;
    private Player player;
    private Animator anim;

    // variabel untuk sprint
    private bool isAbleSprint = false;
    public float decreaseRate = 1f;
    public float variableValue = 5f;
    public float maxMoveSpeed = 10f;
    public TextMeshProUGUI sprintText;
    public Button button;
    public Sprite pressedSprite;

    private Image buttonImage;
    private Sprite defaultSprite;
    //

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        buttonImage = button.GetComponent<Image>();
        defaultSprite = buttonImage.sprite;
    }

    private void FixedUpdate()
    {

        // for input movement with keyboard / arrows
        // float x = Input.GetAxisRaw("Horizontal");
        // float y = Input.GetAxisRaw("Vertical");


        // for input movement with joystick
        float x = joystick.Horizontal;
        float y = joystick.Vertical;


        //reset moveDelta
        moveDelta = new Vector3(x,y,0) * moveSpeed;

        // flip the character, whether you face left or right
        if(moveDelta.x > 0){
            transform.localScale = new Vector3(-1,1,1);
        } else if(moveDelta.x < 0){
            transform.localScale = Vector3.one;
        }
        //

        // character move
        rb.velocity = moveDelta;

        // make animation character
        if (moveDelta.x != 0 || moveDelta.y != 0){
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }
        //

        //script untuk melakukan sprint player
        variableValue -= decreaseRate * Time.deltaTime; // Mengurangi nilai variabel seiring berjalannya waktu
        sprintText.text = Mathf.RoundToInt(variableValue).ToString();

        // Mengecek apakah nilai variabel telah mencapai 0 atau kurang
        if (variableValue <= 0f)
        {
            isAbleSprint = true;
            variableValue = 0f;
            sprintText.text = "";
        }
        else
        {
            isAbleSprint = false;
        }

        if(moveSpeed == maxMoveSpeed && isAbleSprint == true)
        {
            moveSpeed = 5f;
        }

        if(isAbleSprint){
            buttonImage.sprite = defaultSprite;
        } else {
            buttonImage.sprite = pressedSprite;
        }
    }

    public void playerSprint()
    {
        if(isAbleSprint)
        {
            moveSpeed = maxMoveSpeed;
            variableValue = 10f;
        }
    }

    
}
