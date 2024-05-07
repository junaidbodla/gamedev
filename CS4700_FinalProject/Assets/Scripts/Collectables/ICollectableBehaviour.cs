using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface: can be applied to other classes

public interface ICollectableBehaviour
{
    void OnCollected(GameObject player); 

}
