using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private GameObject foodItEats;
    [SerializeField] private float animalSpeed;
    private float lowerBound;
    private bool isOutOfScene;
    private string foodItEatsName;

    // Start is called before the first frame update
    void Start()
    {
        lowerBound = -15f;
        foodItEatsName = foodItEats.name;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            // Call Scoreboard when finished to add to score.
        }
    }
}
