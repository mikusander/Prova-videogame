using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparare : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab della palla o del proiettile
    public Transform launchPoint; // Punto da cui viene lanciato il proiettile
    public float launchForce = 10f; // Forza di lancio del proiettile
    public float upwardForce = 5f; // Forza verso l'alto per creare la parabola
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Controlliamo se il pulsante "W" è stato premuto
        if (Input.GetKeyDown(KeyCode.W))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        // Creiamo un'istanza del proiettile
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);

        // Aggiungiamo un Rigidbody al proiettile, se non lo ha già
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = projectile.AddComponent<Rigidbody>();
        }

        // Applichiamo la forza per far partire il proiettile
        Vector3 forceDirection = launchPoint.forward * launchForce + Vector3.up * upwardForce;
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }
}
