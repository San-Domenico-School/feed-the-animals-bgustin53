using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animals;
    private float spawnRange;
    private float startDelay = 2;
    private float repeatRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, repeatRate);
    }

    private void SpawnAnimal()
    {
        int choice = Random.Range(0, animals.Length - 1);
        float position = Random.Range(-spawnRange, spawnRange);
        Instantiate(animals[choice], new Vector3(0, 0, position), Quaternion.identity);
    }
}
