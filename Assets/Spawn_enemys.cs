using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemys : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies;
    [SerializeField] List<Spawn_point> spawn_Enemies;
    int count;
    [SerializeField] float time_spawn = 2.1f;
    [SerializeField] float time_min = .5f;
    private void Awake()
    {
        count = spawn_Enemies.Count;
    }
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(Time());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            spawn_Enemies[Random.Range(0, count)].Spawn(enemies[0]);
            yield return new WaitForSeconds(time_spawn);
        }
    }

    IEnumerator Time()
    {
        while (true)
        {
            if (time_spawn < time_min)
                StopCoroutine(Time());
            time_spawn -= .1f;
            yield return new WaitForSeconds(10f);
        }
    }


    
}
