using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableObject : MonoBehaviour
{
    public int health;
    private Animator anim;
    
    [SerializeField] private AudioSource hitSound;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // hitSound.Play();
        Debug.Log("damage taken");
    }
}
