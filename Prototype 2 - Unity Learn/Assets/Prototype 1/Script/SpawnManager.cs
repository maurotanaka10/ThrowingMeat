using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn variables")]
    [SerializeField] private GameObject[] animalsPrefabs;
    [Tooltip("Animal Identifier")]
    [SerializeField] private int animalIndex;
    private int randomPositionX;
    private Vector3 spawnPosition;
    [Tooltip("Timer to spawn again")]
    [SerializeField] private float spawnTimer;
    [SerializeField] private float timeToFirstSpawn;

    private void Awake()
    {
        InvokeRepeating("SpawnAnimal", timeToFirstSpawn, spawnTimer);
    }   

    void Update()
    {

    }

    void SpawnAnimal()
    {
            int animalIndex = Random.Range(0, animalsPrefabs.Length);
            int randomPositionX = Random.Range(-12, 12);
            spawnPosition = new Vector3(randomPositionX, 0, 25);
            Instantiate(animalsPrefabs[animalIndex], spawnPosition, animalsPrefabs[animalIndex].transform.rotation);
    }
}
