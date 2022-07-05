using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Max_Score : MonoBehaviour
{
    static public UI_Max_Score instance;
   
    void Start()
    {
        if(UI_Max_Score.instance == null)
            UI_Max_Score.instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        GetComponent<Text>().text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

}
