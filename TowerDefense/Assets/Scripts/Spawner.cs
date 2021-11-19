using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Goblin EnemyPrefab;
    public Transform[] Points;

    //Wave _typeEnemy;
    Wave _currentWave;
    int _currentWaveNumber;

    int _enemyRemainingToSpawn;
    int _enemyRemainingAlive;
    float _nextSpawnTime;


    //private float _timer;
    //private int _index;


    void Start()
    {
        NextWave();
        //_index = 0;
        //_timer = SpawnDeley;

    }


    void Update()
    {
        if (_enemyRemainingToSpawn != 0 && Time.time > _nextSpawnTime)
        {
            _enemyRemainingToSpawn--;
            _nextSpawnTime = Time.time + _currentWave.SpawnDeley;
            Goblin enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.StartHP = _currentWave.EnemyHp;
            _currentWave = waves[_currentWaveNumber - 1];
            enemy.Points = Points;
            enemy.OnDeath += OnEnemyDeath;
            //_timer -= Time.deltaTime;
            //if (_timer <= 0)
            //{
            //    if (_index < EnemyCount)
            //    {
            //        Enemy enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            //        enemy.Points = Points;
            //        _index++;
            //    }
            //    _timer = SpawnDeley;
            //}
        }
    }
    void OnEnemyDeath()
    {
        _enemyRemainingAlive--;
        if (_enemyRemainingAlive == 0)
            NextWave();
    }
    void NextWave()
    {
        _currentWaveNumber++;
        if (_currentWaveNumber - 1 < waves.Length)
        {
            _currentWave = waves[_currentWaveNumber - 1];
            _enemyRemainingToSpawn = _currentWave.EnemyCount;
            _enemyRemainingAlive = _enemyRemainingToSpawn;
        }
    }
    [System.Serializable]
    public class Wave
    {
        public float EnemyHp;
        public int EnemyCount;
        public float SpawnDeley;
    }
}