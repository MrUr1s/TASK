using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0,1,0,ForceMode.Impulse);
    }
}
