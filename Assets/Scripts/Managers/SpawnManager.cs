using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefab;
    private float zStart;
    private float xSpawnRange;
    private float startDelay = 2;
    private float repeatRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        zStart = 30;
        xSpawnRange = 20;
        InvokeRepeating("SpawnAnimal", startDelay, repeatRate);
    }

    private void SpawnAnimal()
    {
        int choice = Random.Range(0, animalPrefab.Length);
        float position = Random.Range(-xSpawnRange, xSpawnRange);
        Instantiate(animalPrefab[choice], new Vector3(position, 0, zStart), Quaternion.Euler(0, 180, 0));
    }
}
