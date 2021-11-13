using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public float SpawnDeley;
    public Transform[] Points;

    private float _timer;
    void Start()
    {
        _timer = SpawnDeley;
    }

   
    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0){
            Enemy enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.Points = Points;

            _timer = SpawnDeley;
        }
    }
}
