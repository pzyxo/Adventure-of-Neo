using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public float bounceForce = 10f; // Besar gaya pantulan

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Cek apakah yang bersentuhan adalah pemain
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                Vector2 bounceDirection = collision.contacts[0].normal; // Dapatkan arah pantulan

                // Terapkan gaya pantulan pada pemain
                playerRigidbody.velocity = Vector2.zero; // Nolkan kecepatan sebelumnya
                playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
