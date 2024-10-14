using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float spawnTimer;
    float spawnRate = 3f;
    public GameObject Enemy;
    public static bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnRate && !gameover)
        {
            spawnTimer -= spawnRate;
            Vector2 spawnPos = new Vector2(0, 5.5f);
            Instantiate(Enemy, spawnPos, Quaternion.identity);
        }
    }
}
