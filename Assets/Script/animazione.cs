using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animazione : MonoBehaviour
{
    public Sprite[] characterSprites; // Array di sprite per il personaggio
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del personaggio
    private int countDestra = 1;

    void Start()
    {
        // Ottieni il componente SpriteRenderer dal GameObject del personaggio
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Imposta lo sprite iniziale, se l'array di sprite non è vuoto
        if (characterSprites.Length > 0)
        {
            spriteRenderer.sprite = characterSprites[0];
        }
    }

    void Update()
    {
        // Controlla se viene premuto il tasto "D" o la freccia destra
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            // Aggiorna lo sprite del personaggio
            spriteRenderer.sprite = characterSprites[countDestra];
        }
    }
}
