using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemys : MonoBehaviour
{
    static public Spawn_enemys instance;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] List<Spawn_point> spawn_Enemies;
    int count_spawn, count_enemy;
    [SerializeField] float time_spawn = 2f;
    [SerializeField] float time_min = .5f;
    private void Awake()
    {
        if (Spawn_enemys.instance == null)
            Spawn_enemys.instance = this;
        else
        {
            StopAllCoroutines();
            Destroy(gameObject);
            return;
        }
        Event_system.gameOver.Subscribe(GameOver);
        count_spawn = spawn_Enemies.Count;
        count_enemy = enemies.Count;
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
            spawn_Enemies[Random.Range(0, count_spawn)].Spawn(Chance_spawn());
            yield return new WaitForSeconds(time_spawn);
        }
    }

    Enemy Chance_spawn()
    {
        int weight_enemy = 0;
        for (int i = 0; i < count_enemy; i++)
            weight_enemy+=enemies[i].chance;
        int random_value=Random.Range(0, weight_enemy);
        for(int i=0; i < count_enemy; i++)
        {
            if(random_value<=enemies[i].chance)
            {
                return enemies[i];
            }
            random_value-=enemies[i].chance;
        }
        Debug.Log("Error");
        return enemies[0];
    }

    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (time_spawn < time_min)
                StopCoroutine(Time());
            time_spawn -= .1f;
        }
    }

    private void GameOver(Player obj)
    {
        instance.StopAllCoroutines();
    }

}
