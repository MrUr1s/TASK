using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int maxHP;
    int hP;
    public int HP
    {
        get { return hP; }

        set 
        { 
            if(value > 0)
                hP = value;
            else
            Destroy(this.gameObject);
        }
    }
    [SerializeField]
    float speed=2f;
    [SerializeField]
    int score = 7;
    public int chance = 60;
    [SerializeField]
    Vector3 target;
    [SerializeField]
    float time = 0;
    void Awake()
    {
        HP = maxHP;
        target=FindObjectOfType<Player>().transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullets")
        {
            HP--;
        }
    }

}
