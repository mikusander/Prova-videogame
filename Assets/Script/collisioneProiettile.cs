using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioneProiettile : MonoBehaviour
{
    public Sprite[] characterSprites; // Array di sprite per il personaggio
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del personaggio
    public float explosionDuration = 0.01f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = characterSprites[0];
    }

    void Update()
    {
        if(transform.position.y < -3.8)
        {
            // Imposta la velocità del Rigidbody a zero
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;  // Rende il Rigidbody kinematic per bloccare il movimento
            StartCoroutine(ExplodeAndDestroy());
        }
    }
    IEnumerator ExplodeAndDestroy()
    {
        spriteRenderer.sprite = characterSprites[1];
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Controlliamo il tag dell'oggetto con cui il proiettile entra in collisione
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Distrugge il proiettile
        }
    }
}
