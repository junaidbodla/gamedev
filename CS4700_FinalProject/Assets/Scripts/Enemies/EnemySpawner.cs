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
     private float _spawnDuration;

    private float _timeUntilSpawn;
    private float _spawnTimer;
    public Slider timer;

    void Awake()
    {
        SetTimeUntilSpawn();
	//Set timer and slider to whatever spawn duration
	timer.maxValue = _spawnDuration;
	_spawnTimer = _spawnDuration;
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }

	//once spawn timer is at 0 stop spawning
	_spawnTimer -= Time.deltaTime;
	if (_spawnTimer <= 0 ) {
		enabled = false;
	}

	//slider to show time
	if (timer != null) {
		timer.value = _spawnTimer;
	}
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
