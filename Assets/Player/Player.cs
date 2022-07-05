using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

    [SerializeField] Bullet bullet;   
    [SerializeField] Vector3 target=new Vector3(0,0);
    [SerializeField] float rate_of_fire = 10f;

    private void Awake()
    {
        Debug.Log("player");
        if (instance == null)
        {
            instance = this;            
            Event_system.gameOver.Subscribe(GameOver);
        }
        else
        {
            StopAllCoroutines();
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(gameObject);
        
    }


    void Start()
    {           
        Input.simulateMouseWithTouches = true;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 1));

    }
    IEnumerator Shoot()
    {
        while(true)
        {
            Instantiate(bullet, transform.position,
             Quaternion.Euler(0, 0, Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg - 90));
            yield return new WaitForSeconds(1/rate_of_fire);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(target, new Vector3(1, 1, 1));

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Event_system.gameOver.Publish(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            Event_system.gameOver.Publish(this);
        }
    }

    private void GameOver(Player player)
    {
        instance.StopAllCoroutines();
    }
}
