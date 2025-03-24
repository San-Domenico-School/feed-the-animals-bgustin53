using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*******************************************************************  
 * Class: PlayerMovementController  
 * Purpose: Controls player movement based on input.  
 * Component Of: Player GameObject  
 * Fields: 
 *   - playerSpeed (float) → Controls movement speed.  
 *   - centerToEdge (float) → Prevents movement beyond boundaries.  
 *   - moveDirection (float) → Stores input direction.    
 * Behaviors:
 *   - Start() → Initializes variables.  
 *   - Update() → Executes the PlayerMovement methods per frame.
 *   - OnMovementInput() → Handles player input events.
 *   - DeterminePlayerDirection() → Assigns player's move direction 
 *                                1, 0, -1 to moveDirection.
 *   - PlayerMovement() → Proces«ses movement logic.
 * Access: All members are private to enforce encapsulation.  
 * Author: Your Name
 * Version: 1.0
 **********************************************************************/


public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private float centerToEdge;
    private float moveDirection;

    // Start is called before the first frame update«
    void Start()
    {
        centerToEdge = 20.0f;
    }

    // Causes PlayerMovement to be called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    //Dynamic Method that handles player input events.
    public void OnMovementInput(InputAction.CallbackContext ctx) => DeterminePlayerDirection(ctx.ReadValue<Vector2>());

    //Assigns player's move direction 1, 0, -1 to moveDirection.
    private void DeterminePlayerDirection(Vector2 xValue)
    { 
        moveDirection = xValue.x;
    }

    //Processes movement logic
    private void PlayerMovement()
    {
        // Moves if in field of play
        if (transform.position.x >= -centerToEdge && moveDirection < 0 ||
            transform.position.x <=  centerToEdge && moveDirection > 0)
        {
            transform.Translate(Vector3.right * playerSpeed * moveDirection * Time.deltaTime);
        }
    }
}
