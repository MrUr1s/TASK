using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float time_to_deths=5f;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 350, 0));
        StartCoroutine(Deths());
    }
   
    IEnumerator Deths()
    {
        yield return new WaitForSeconds(time_to_deths);
        Destroy(gameObject);
    }
}
