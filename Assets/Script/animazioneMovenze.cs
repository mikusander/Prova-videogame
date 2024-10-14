using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animazioneMovenze : MonoBehaviour
{
    public Sprite[] characterSprites; // Array di sprite per il personaggio
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del personaggio
    private int countDestra = 1;
    private int frameGiustoDestra = 0;
    private int countSinistra = 3;
    private int frameGiustoSinistra = 0;
    private Vector3 previousPosition;  // La posizione del frame precedente
    private PlayerMovement2D movement;
    public string lastKeycode;

    void Start()
    {
        movement = GetComponent<PlayerMovement2D>();
        // Ottieni il componente SpriteRenderer dal GameObject del personaggio
        spriteRenderer = GetComponent<SpriteRenderer>();

        previousPosition = transform.position;
        
        // Imposta lo sprite iniziale, se l'array di sprite non è vuoto
        if (characterSprites.Length > 0)
        {
            spriteRenderer.sprite = characterSprites[0];
        }
    }

    void Update()
    {
        if (transform.position.x == previousPosition.x && transform.position.y < previousPosition.y && movement.isGrounded)
        {
            spriteRenderer.sprite = characterSprites[0];
        }
        else if (transform.position.x == previousPosition.x && Input.GetKeyDown(KeyCode.Space))
        {
            lastKeycode = "Space";
            spriteRenderer.sprite = characterSprites[7];
        }
        else if(!Input.anyKey && lastKeycode == "D" && movement.isGrounded)
        {
            spriteRenderer.sprite = characterSprites[5];
        }
        else if (!Input.anyKey && lastKeycode == "A" && movement.isGrounded)
        {
            spriteRenderer.sprite = characterSprites[6];
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            lastKeycode = "W";
            spriteRenderer.sprite = characterSprites[0];
        }
        // Controlla se viene premuto il tasto "D" o la freccia destra
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            lastKeycode = "D";
            spriteRenderer.sprite = characterSprites[countDestra];
            // Aggiorna lo sprite del personaggio
            if(frameGiustoDestra == 50)
            {
                countDestra = ((countDestra % 2) + 1);
                frameGiustoDestra = 0;
            }
            else
            {
                frameGiustoDestra++;
            }
        }
        
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lastKeycode = "A";
            spriteRenderer.sprite = characterSprites[countSinistra];
            if(frameGiustoSinistra == 50)
            {
                countSinistra = ((countSinistra % 2) + 3);
                frameGiustoSinistra = 0;
            }
            else
            {
                frameGiustoSinistra++;
            }
        }
        previousPosition = transform.position;
    }
}
