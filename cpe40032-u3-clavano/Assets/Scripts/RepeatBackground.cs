using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Basically startPos here will always equal to our transform position so we'll know when the position hits its boundary.
        startPos = transform.position;
        // This gets our backgrounds horizontal size to get the half size to be repeated over and over.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;  
        
    }

    // Update is called once per frame
    void Update()
    {
        // This if statement basically says that when our background reached its width boundary it will repeat and repeat it seamlessly.
        if (transform.position.x < startPos.x - repeatWidth)
        {
             transform.position = startPos;
        }
    }
}
