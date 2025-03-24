using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*******************************************************************  
 * Purpose: Controls feeding the animals based on input.  
 * Component Of: Player GameObject   
 * Author: B. Gustin
 * Version: 1.0
 **********************************************************************/

public class FeedTheAnimals : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private float force;

    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        // Handle action only if it's started
        if (ctx.started)
        {
             FeedAnimal(ctx.control.name);  //Sents button name to 
        }
    }

    private void FeedAnimal(string buttonName)
    {
        // Instantiate the food at the position above the animal
        Vector3 position = transform.position + new Vector3(0, 2, 0);
        GameObject foodInstance = Instantiate(food, position, Quaternion.identity);

        // Get the Rigidbody from the instantiated food object
        Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();

        // If the Rigidbody is found, apply force
        if (foodRB != null)
        {
            foodRB.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }
}
