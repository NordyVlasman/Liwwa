using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    public Transform SpawnPoint;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached; 
    public CountdownScript cdScript;

    public float countdown = 20f;


    void Awake()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            checkpointSpriteRenderer.sprite = greenFlag;
            SpawnPoint.transform.position = transform.position;
            cdScript.timer += 20f;
            checkpointReached = true; 
        }
    }
}
