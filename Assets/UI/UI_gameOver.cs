using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gameOver : MonoBehaviour
{
    static public UI_gameOver instance;

    [SerializeField]
    Text score;

    private void Awake()
    {
        if (instance == null)
        {
            Event_system.gameOver.Subscribe(gameOver);           
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        instance.gameObject.SetActive(false);
    }

    private void gameOver(Player obj)
    {
        score.text = Event_system.Score.ToString();
        instance.gameObject.SetActive(true);
    }
}
