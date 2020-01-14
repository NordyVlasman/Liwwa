using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;

    public AudioSource audioSource;
        
    public AudioClip buttonSound;
    public AudioClip doorSound;

    int numOpening = 0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            numOpening++;
            door.SetActive(true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            numOpening--;
            door.SetActive(false);
            audioSource.PlayOneShot(buttonSound);
            audioSource.PlayOneShot(doorSound);
        }

    }
}
