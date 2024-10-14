using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveBounceMultiAxis : MonoBehaviour
{
    public float speed = 5f; // Velocità del movimento
    private Vector3 direction = new Vector3(1, 0, 0); // Direzione iniziale (X e Z)
    private Camera mainCamera;
    public float targetX = 2.6f; // Posizione target (sia positiva che negativa)

    void Start()
    {
        if((Random.Range(0, 2) == 0))
        {
            direction.x = -direction.x;
        }
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
    }
}
