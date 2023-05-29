using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDelta;
    public float moveSpeed = 5f;

        
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // for input movement with keyboard / arrows
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        // // for input movement with joystick
        // float x = joystick.Horizontal;
        // float y = joystick.Vertical;

        //reset moveDelta
        moveDelta = new Vector3(x,y,0) * moveSpeed;
        
        if(moveDelta.x > 0){
            transform.localScale = new Vector3(-1,1,1);
        } else if(moveDelta.x < 0){
            transform.localScale = Vector3.one;
        }

        // character move
        rb.velocity = moveDelta;

        // make animation character
        if (moveDelta.x != 0 || moveDelta.y != 0){
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }
        //
    }
}
