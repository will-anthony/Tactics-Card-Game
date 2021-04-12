using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour


{
    [SerializeField] private int staminaCost;
    private StaminaTracker staminaTracker;


    void Start()
    {
        staminaCost = 1;
        staminaTracker = gameObject.GetComponent<StaminaTracker>();
    }

    void Update()
    {
        move();
    }



    /* move()
     * 
     * The move() method checks for input each frame then checks if the new position is inside the game board.
     * If above returns true, move() then checks if the player object has enough stamina to make the move. If 
     * requestStamina() returns true, the player moves to the requested position.
     * 
     */

    private void move()
    {
        Vector3 pos = transform.position;

        if (Input.GetKeyDown("up") && checkForGround(new Vector3(pos.x, pos.y - 1f, pos.z + 1)))
        {
            if (requestStamina())
            {
                transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
            }
        }
        else if (Input.GetKeyDown("down") && checkForGround(new Vector3(pos.x, pos.y - 1f, pos.z - 1)))
        {
            if (requestStamina())
            {
                transform.position = new Vector3(pos.x, pos.y, pos.z - 1);
            }
        }
        else if (Input.GetKeyDown("right") && checkForGround(new Vector3(pos.x + 1, pos.y - 1f, pos.z)))
        {
            if (requestStamina())
            {
                transform.position = new Vector3(pos.x + 1, pos.y, pos.z);
            }
        }
        else if (Input.GetKeyDown("left") && checkForGround(new Vector3(pos.x - 1, pos.y - 1f, pos.z + 1)))
        {
            if (requestStamina())
            {
                transform.position = new Vector3(pos.x - 1, pos.y, pos.z);
            }
        }
    }

    private bool requestStamina()
    {
        if (staminaTracker.RequestStamina(staminaCost))
        {
            return true;
        }

        return false;
    }

    private bool checkForGround(Vector3 check)
    {
        Collider[] intersecting = Physics.OverlapSphere(check, 0.01f);
        if (intersecting.Length > 0)
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("checkForGround = false");
            return false;
        }

    }
}
