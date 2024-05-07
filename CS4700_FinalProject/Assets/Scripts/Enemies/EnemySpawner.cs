using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    //private float _spawnDuration;

    private float _timeUntilSpawn;
    //private float _spawnTimer;
    //public Slider timer;
    public LevelManager levelManager;

    void Awake()
    {
        SetTimeUntilSpawn();
	    //Set timer and slider to whatever spawn duration

        if(!levelManager)
        {
            levelManager = FindObjectOfType<LevelManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.getSpawnTimer() > 0)
        {
            _timeUntilSpawn -= Time.deltaTime;

            if (_timeUntilSpawn <= 0)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
            }
        }
        else
        {
            enabled = false;
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
