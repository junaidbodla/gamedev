using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehavior : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private int _healthValue;

    public void OnCollected(GameObject player)
    {
        player.GetComponent<PlayerHealth>().IncreaseHealth(_healthValue);
         
    }
}
