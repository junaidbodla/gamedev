using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        //first gets the location of where the mouse is and subtracts it from player's location to get the cursor's location relative to the player
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerTransform.position;
        //using that location (which is a vector), it calculates the angle of how much the player need to rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        //creates a quaternion with a rotation in the z-axis, the angle-90 is to account for the default sprite which faces up
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        playerTransform.rotation = rotation;
    }
}
