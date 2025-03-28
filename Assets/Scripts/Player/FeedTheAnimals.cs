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
    [SerializeField] private GameObject[] foods;
    [SerializeField] private float maxForce;
    [SerializeField] private AudioSource audioSource;

    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        // Handle action only if it's started
        if (ctx.started)
        {
             SelectFood(ctx.control.name);  //Sents button name to 
        }
    }

    private void SelectFood(string keyName)
    {
        switch (keyName)
        {
            case "z":
                FeedAnimal(0, 1, false);
                break;
            case "x":
                FeedAnimal(1, 1, false);
                break;
            case "c":
                FeedAnimal(2, 100, false);
                break;
            case "space":
                FeedAnimal(2, 99, true);
                break;
        }
    }

    private void FeedAnimal(int index, int foodCount, bool allFood)
    {
        // Instantiate the food at the position above the animal
        Vector3 position = transform.position + new Vector3(0, 2, 0);
        audioSource.Play();

        for (int i = 0; i < foodCount; i++)
        {

            GameObject foodInstance = Instantiate(foods[index], position, Quaternion.identity);
            // Get the Rigidbody from the instantiated food object
            Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();

            // If the Rigidbody is found, apply force
            if (foodRB != null)
            {
                float force = maxForce * Random.Range(0.6f, 1f);
                foodRB.AddForce(new Vector3(Random.Range(-0.1f, 0.1f), 0, 1) * force, ForceMode.Impulse);

            }
        }

        if(allFood)
        {
            foreach(GameObject food in foods)
            {
                GameObject foodInstance = Instantiate(food, position, Quaternion.identity);
                // Get the Rigidbody from the instantiated food object
                Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();

                // If the Rigidbody is found, apply force
                if (foodRB != null)
                {
                    float force = maxForce * Random.Range(0.6f, 1f);
                    foodRB.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 0, 1) * force, ForceMode.Impulse);

                }

            }
        }

    }
}
