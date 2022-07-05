using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int maxHP;
    [SerializeField]
    int hP;
    public int HP
    {
        get { return hP; }

        set 
        {
            if (value > 0)
                hP = value;
            else
            {
                Destroy(this.gameObject);
                Event_system.UnitDied.Publish(this);
            }
        }
    }

    [SerializeField]
    int score = 7;
    public int Score { get => score; set => score = value; }

    [SerializeField]
    float speed=2f;
    public int chance = 60;
    [SerializeField]
    Vector3 target;



    void Start()
    {
        HP = maxHP;
        var player = FindObjectOfType<Player>();
        if(player != null)
        target = player.transform.position;
    }



    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            HP--;
            Destroy(other.gameObject);
        }
    }

}
