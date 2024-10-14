using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Collider2D playerCollider;
    private float fallThroughTime = 0.5f;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;
    public GameObject gameover;
    public GameObject restart;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        // Ottieni i confini dello schermo
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        // Calcola la larghezza e altezza del personaggio
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Salto solo se il personaggio è a terra
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Limita la posizione del personaggio ai bordi della camera
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        transform.position = viewPos;

        if ((transform.position.y > -3) && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            StartCoroutine(DisableCollisionTemporarily());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameController.gameover = true;
            gameover.SetActive(true);
            restart.SetActive(true);
        }
    }

    private IEnumerator DisableCollisionTemporarily()
    {
        // Disabilita la collisione con le piattaforme
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platform"), true);

        // Aspetta un breve periodo di tempo (tempo per attraversare la piattaforma)
        yield return new WaitForSeconds(fallThroughTime);

        // Riabilita la collisione con le piattaforme
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platform"), false);
    }
}
