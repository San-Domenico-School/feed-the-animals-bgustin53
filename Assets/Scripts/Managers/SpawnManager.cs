using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefab;
    private float zStart;
    private float xSpawnRange;
    private float startDelay = 2;
    private float repeatRate = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        zStart = 30;
        xSpawnRange = 20;
        InvokeRepeating("SpawnAnimal", startDelay, repeatRate);
    }

    private void SpawnAnimal()
    {
        // Choose a random index from the animalPrefab array
        // Random.Range(0, animalPrefab.Length) generates a random number between 0 and the length of the animalPrefab array (exclusive)
        int choice = Random.Range(0, animalPrefab.Length);

        // Generate a random spawn position on the X axis within the specified range (-xSpawnRange to xSpawnRange)
        float position = Random.Range(-xSpawnRange, xSpawnRange);

        // Instantiate (create) a new animal object at the chosen position with the desired rotation
        // animalPrefab[choice] gets the animal prefab based on the random choice
        // new Vector3(position, 0, zStart) sets the spawn position in 3D space (X: random, Y: 0, Z: zStart)
        // Quaternion.Euler(0, 180, 0) sets the animal's rotation to 180 degrees on the Y axis (flipping it horizontally)
        Instantiate(animalPrefab[choice], new Vector3(position, 0, zStart), Quaternion.Euler(0, 180, 0));
    }
}
