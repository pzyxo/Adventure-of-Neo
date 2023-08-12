using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool pressed;
    
    public Transform attackPos = null;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsObjects;
    private Animator anim;
    public float attackRange;
    public int damage;

    [SerializeField] private AudioSource hitSoundEffect;
    [SerializeField] private AudioSource bushHitSound;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(timeBtwAttack <= 0)
        {
            if(pressed)
            {
                hitSoundEffect.Play();
                anim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                Collider2D[] removeObject = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsObjects);
                for (int i = 0; i < removeObject.Length; i++)
                {
                    removeObject[i].GetComponent<RemovableObject>().TakeDamage(damage);
                    bushHitSound.Play();
                }
                timeBtwAttack = startTimeBtwAttack;
                pressed = false;
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
