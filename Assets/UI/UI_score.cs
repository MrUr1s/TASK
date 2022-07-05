using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_score : MonoBehaviour
{
    static public UI_score instance;
    [SerializeField] public
    Text text;

    private void Awake()
    {       
        if (instance==null)
        {
            instance = this;           
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Event_system.UnitDied.Subscribe(onUnitDeths);
        instance.text.text = Event_system.Score.ToString();
        DontDestroyOnLoad(this.gameObject);
    } 

    void onUnitDeths(Enemy enemy)
    {
        Event_system.Score += enemy.Score;
        text.text = Event_system.Score.ToString();
    }

}
