using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] Vector3 target=new Vector3(0,0);
    [SerializeField] float rate_of_fire = 10f;
    LineRenderer lineRenderer;


    void Start()
    {
        Input.simulateMouseWithTouches = true;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0,transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)        
            if (touch.phase == TouchPhase.Began)
            {
                target = touch.position;
                lineRenderer.SetPosition(1, target);
            }
        
    }

    IEnumerator shoot()
    {
        while(true)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1/rate_of_fire);
        }
    }

    
}
