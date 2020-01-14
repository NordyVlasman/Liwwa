using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Serval.Player;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    public CountdownScript cdScript;
    

    public List<PlayerController> playerController;

    [SerializeField] Text CountdownText;
    public GameObject panel;
    
    void Start()
    {
        panel.SetActive(true);
        CountdownText.gameObject.SetActive(true);
        foreach(PlayerController cont in playerController) {
            cont.controlEnabled = false;
        }
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString ("0");
        if(currentTime <= 0) {
            currentTime = 0;
            panel.SetActive(false);
            CountdownText.gameObject.SetActive(false);
            cdScript.startCount = true;
            foreach(PlayerController cont in playerController) {
                cont.controlEnabled = true;
                
            }
            //gameObject.SetActive(false);   
        }
    }
}
