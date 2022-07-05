using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Event_system : MonoBehaviour
{
    public static UnitDiedEvent UnitDied=new UnitDiedEvent();
    public static GameOverEvent gameOver = new GameOverEvent();
    public static RestartEvent restart = new RestartEvent();
    private static int score = 0;

    public static int Score 
    { 
        get => score;
        set
        {            
            score = value;
            if (PlayerPrefs.GetInt("MaxScore") < Score)
                PlayerPrefs.SetInt("MaxScore", Score);
        }
    }

    public static void Restart()
    {
        UI_gameOver.instance.gameObject.SetActive(false);
        UI_score.instance.text.text = "0";
        Score = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }
}
