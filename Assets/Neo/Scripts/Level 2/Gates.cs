using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private Animator anim;
    public static bool isOpening;
    private float timeBtwOpening = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpening)
        {
            anim.SetBool("opening", true);
            timeBtwOpening -= Time.deltaTime;
        }

        if(timeBtwOpening <= 0)
        {
            RemoveCollider();
        }
    }

    public static void OpeningGate()
    {
        isOpening = true;
        Debug.Log("Gate opening");
    }

    void RemoveCollider()
    {
        // Mendapatkan komponen Collider2D pada objek ini
        Collider2D collider = GetComponent<Collider2D>();

        // Memeriksa apakah komponen Collider2D ditemukan
        if (collider != null)
        {
            // Menghapus komponen Collider2D dari objek ini
            Destroy(collider);
        }
    }
}
