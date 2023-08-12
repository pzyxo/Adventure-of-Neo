using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool pressed;
    private float timeBtwAttack;
    private float startTimeBtwAttack = 1;
    
    public Transform attackPos = null;
    public LayerMask whatIsChest;
    private Animator anim;
    public float attackRange;

    [SerializeField] private AudioSource hitSoundEffect;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(pressed)
            {
                // anim.SetBool("interact", true);
                hitSoundEffect.Play();

                Collider2D[] openChest = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsChest);
                for (int i = 0; i < openChest.Length; i++)
                {
                    openChest[i].GetComponent<ChestInteract>().ChestOpening();
                }

                timeBtwAttack = startTimeBtwAttack;

            } else {
                // anim.SetBool("interact", false);
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }

            
    }

    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void OnDownAction()
    {
        pressed = true;
    }

    public void OnUpAction()
    {
        pressed = false;
    }
}
