using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehavior;

    private void Awake()
    {
        _collectableBehavior = GetComponent<ICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>(); //check if collider is player

        if (player != null) //means player collided with it 
        {
            _collectableBehavior.OnCollected(player.gameObject);
            Destroy(gameObject); //destroy collectable
            
        }
    }
}
