using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectableDrop;

    private AmmoSpawner _ammoSpawner;

    private void Awake()
    {
        _ammoSpawner = FindObjectOfType<AmmoSpawner>();

    }
    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0f, 1f);

        if (_chanceOfCollectableDrop >= random)
        {
            _ammoSpawner.SpawnCollectable(transform.position);
        }
    }
}
