using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool pressed;
    
    public Transform attackPos = null;
    public LayerMask whatIsEnemies;
    private Animator anim;
    public float attackRange;
    public int damage;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(pressed)
            {
                anim.SetBool("attack", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                
                timeBtwAttack = startTimeBtwAttack;
            } else {
                anim.SetBool("attack", false);
            }

            
        }
        else
        {
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
