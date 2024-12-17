using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    List<int> availableLanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnApple()
    {
        if(UnityEngine.Random.value > appleSpawnChance || availableLanes.Count <= 0) { return; }

        int selectedLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);


    }
    private void SpawnCoins()
    {
        if(UnityEngine.Random.value > coinSpawnChance || availableLanes.Count <= 0) { return; }

        int selectedLane = SelectLane();
        
        int maxCoinsToSpawn = 6;
        int coinsToSpawn = UnityEngine.Random.Range(1,maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i*coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    private void SpawnFences()
    {
        int fencesToSpawn = UnityEngine.Random.Range(0, 3);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) { break; }

            int selectedLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);

        }
    }

    private int SelectLane()
    {
        int randomeLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomeLaneIndex];
        availableLanes.RemoveAt(randomeLaneIndex);
        return selectedLane;
    }

}
