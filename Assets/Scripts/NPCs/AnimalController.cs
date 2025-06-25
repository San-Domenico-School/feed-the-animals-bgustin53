using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private GameObject foodItEats;
    [SerializeField] private float animalSpeed;
    private float lowerBound;
    private bool isOutOfScene;
    private bool notHungry;

    // Start is called before the first frame update
    void Start()
    {
        lowerBound = -15f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        DeleteOutOfScene();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * animalSpeed * Time.deltaTime);
    }

    private void DeleteOutOfScene()
    {
        if(!isOutOfScene)
        {
            if(transform.position.z < lowerBound)
            {
                isOutOfScene = true;
                Destroy(gameObject);
            }
        }
    }

    private bool IsFoodItEats(string foodTriggered)
    {
        string foodItEatsName = foodItEats.name;

        // Remove "(Clone)" if it exists
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
            foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
        }

        // Compare the cleaned names
        return foodTriggered.Equals(foodItEatsName);

        // REMOVE RETURN FALSE

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food") && !notHungry)
        {
            bool isFoodItEats = IsFoodItEats(other.gameObject.name);
            if (other.gameObject.name.Equals("Not Picky"))
            {
                isFoodItEats = true;
            }

            if (isFoodItEats)
            {
                Debug.Log("AnimalController_69 - Add a point");
                // Debug from Previous assignment.  Then add in Scoreboard assignment next
                Scorekeeper.Instance.UpdateScore(1);
            }
            else
            {
                Debug.Log("AnimalController_73 - Subtract a point");
                Scorekeeper.Instance.UpdateScore(-1);
            }

            notHungry = true;
            Destroy(other.gameObject);
            
        }
    }
}
