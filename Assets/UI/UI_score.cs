using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_score : MonoBehaviour
{
    static public UI_score instance;
    [SerializeField]
    Text text;

    private void Awake()
    {      
        DontDestroyOnLoad(this.gameObject);
        if (instance==null)
        {
            instance = this;
            Event_system.UnitDied.Subscribe(onUnitDeths);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    } 

    void onUnitDeths(Enemy enemy)
    {
        Event_system.Score += enemy.Score;
        text.text = Event_system.Score.ToString();
    }

}
