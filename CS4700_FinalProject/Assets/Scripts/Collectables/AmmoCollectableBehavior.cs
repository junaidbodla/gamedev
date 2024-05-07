using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectableBehavior : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private int _ammoValue;

    public void OnCollected(GameObject player)
    {
        player.GetComponent<Weapon>().addAmmo(_ammoValue);

    }
}
