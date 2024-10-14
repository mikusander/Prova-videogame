using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveBounceMultiAxis : MonoBehaviour
{
    public float speed = 5f; // Velocità del movimento
    private Vector3 direction = new Vector3(1, 0, 0); // Direzione iniziale (X e Z)
    private Camera mainCamera;
    public float targetX = 2.6f; // Posizione target (sia positiva che negativa)
    public Sprite[] characterSprites; // Array di sprite per il personaggio
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del personaggio
    public float explosionDuration = 0.01f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if ((Random.Range(0, 2) == 0))
        {
            direction.x = -direction.x;
        }
        spriteRenderer.sprite = characterSprites[0];
    }

    void Update()
    {
        // Spostiamo il personaggio
        transform.Translate(direction * speed * Time.deltaTime);
        float posX = transform.position.x;

        // Controlliamo se il personaggio è vicino a x = 2.6 o x = -2.6
        if (posX > 2.6f || posX < -2.6f)
        {
            direction.x = -direction.x; // Invertiamo solo l'asse X
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            direction.x = -direction.x;
        }
        else if (collision.gameObject.tag == "proiettile")
        {
            // Imposta la velocità del Rigidbody a zero
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;  // Rende il Rigidbody kinematic per bloccare il movimento
            StartCoroutine(DeathAndDestroy());
        }
    }
    IEnumerator DeathAndDestroy()
    {
        Punti.punteggio += 1;
        spriteRenderer.sprite = characterSprites[1];
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }
}
