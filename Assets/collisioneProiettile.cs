using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioneProiettile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Controlliamo il tag dell'oggetto con cui il proiettile entra in collisione
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Distrugge il proiettile
        }
    }
}
