using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparare : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab della palla o del proiettile
    public Transform launchPointRight; // Punto da cui viene lanciato il proiettile
    public Transform launchPointLeft;
    public float launchForce = 5f; // Forza di lancio del proiettile
    public float upwardForce = 5f; // Forza verso l'alto per creare la parabola
    public GameObject player;
    public animazioneMovenze playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<animazioneMovenze>();
    }

    // Update is called once per frame
    void Update()
    {
        // Controlliamo se il pulsante "e" è stato premuto
        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        // Creiamo un'istanza del proiettile
        if (playerScript.lastKeycode == "D")
        {
            // Istanzia il proiettile con la posizione e rotazione corrette
            GameObject projectile = Instantiate(projectilePrefab, launchPointRight.position, launchPointRight.rotation);

            // Aggiungiamo un Rigidbody2D al proiettile, se non lo ha già
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Calcoliamo la direzione della forza in 2D
            // Movimento a destra sull'asse x (orizzontale) e verso l'alto sull'asse y (verticale)
            Vector2 forceDirection = new Vector2(launchForce, upwardForce);

            // Applichiamo la forza per far partire il proiettile
            rb.AddForce(forceDirection, ForceMode2D.Impulse);

        }
        else if (playerScript.lastKeycode == "A")
        {
            // Istanzia il proiettile con la posizione e rotazione corrette
            GameObject projectile = Instantiate(projectilePrefab, launchPointLeft.position, launchPointLeft.rotation);

            // Aggiungiamo un Rigidbody2D al proiettile, se non lo ha già
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Calcoliamo la direzione della forza in 2D
            // Movimento a destra sull'asse x (orizzontale) e verso l'alto sull'asse y (verticale)
            Vector2 forceDirection = new Vector2(-launchForce, upwardForce);

            // Applichiamo la forza per far partire il proiettile
            rb.AddForce(forceDirection, ForceMode2D.Impulse);
        }
        else if (playerScript.lastKeycode == "W") 
        {
            GameObject projectile = Instantiate(projectilePrefab, launchPointLeft.position, launchPointLeft.rotation);
            // Aggiungiamo un Rigidbody al proiettile, se non lo ha già
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Applichiamo la forza per far partire il proiettile
            Vector3 forceDirection = launchPointLeft.forward * launchForce + Vector3.up * upwardForce;
            rb.AddForce(forceDirection, ForceMode2D.Impulse);
        }
    }
}
