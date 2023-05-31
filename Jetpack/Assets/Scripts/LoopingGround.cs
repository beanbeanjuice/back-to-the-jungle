using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    public GameObject groundPrefab;
    public float spawnDistance = 94.53f;
    public GameObject player;

    private float lastSpawnPosition;

    private void Start()
    {
        this.lastSpawnPosition = groundPrefab.transform.position.x;
    }

    private void Update()
    {
        float playerPosition = player.transform.position.x;

        if (playerPosition > (this.lastSpawnPosition + this.spawnDistance) / 2)
        {
            SpawnGround();
            lastSpawnPosition += spawnDistance;
        }
    }

    private void SpawnGround()
    {
        GameObject newGround = Instantiate(groundPrefab, transform);
        float yPos = groundPrefab.transform.position.y;
        newGround.transform.position = new Vector2(lastSpawnPosition + spawnDistance, yPos);
    }
}
