using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Refers to our obstacle..
    public GameObject obstaclePrefab;
    // This is the spawn position where the obstacles are to be spawned...
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    // Another PlayerController reference here...
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Like in MoveLeft script we will look for the player so we can reference when to stop spawning obstacles after the game ended.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Unless our game over equals to false... Our game will continue to run.
        if (playerControllerScript.gameOver == false)
        {
            // This will instatiate your obstacles to be spawned in the game..
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
