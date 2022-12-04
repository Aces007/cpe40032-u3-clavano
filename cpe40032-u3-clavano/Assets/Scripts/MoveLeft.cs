using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
    private float speed = 40;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
    // This line basically looks for our player so we know when it collides with the obstacles and game over is initialized..
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
        // Unless we hit an obstacle, the background and our gameobjects will continue to move to the left...
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // This if statement says that if our gameobject tagged obstacle goes past the boundary to the left, it is to be destroyed..
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
