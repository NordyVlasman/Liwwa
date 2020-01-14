using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Serval.Player;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;

    public bool startCount = false;
    
    public float timer = 20f;
    private bool canCount = true;
    private bool doOnce = false;

    void Update()
    {
        if (!startCount)
            return;
        
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "De tijd is op!";
            timer = 0.0f;
            
        }
    } 
}

