using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(20, 0, 0);

    private PlayerController playerController;

    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    private float repeatMinInterval = 1.0f;
    private float repeatMaxInterval = 3.5f;

    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!playerController.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }

    private float RandomSpawnObstacleInterval()
    {
        return Random.Range(repeatMinInterval, repeatMaxInterval);
    }
}
