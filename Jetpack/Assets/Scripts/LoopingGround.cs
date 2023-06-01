using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject grid;
    [SerializeField] private float spawnDistance; // ground length
    [SerializeField] private GameObject player;
    [SerializeField] private float secondsBeforeDelete;

    private float lastSpawnPosition;

    private void Start()
    {
        this.lastSpawnPosition = groundPrefab.transform.position.x; // -15.7, -9.89

    }

    private void Update()
    {
        float playerPosition = player.transform.position.x;
        if (playerPosition > (this.lastSpawnPosition + this.spawnDistance) / 2)
        {
            SpawnGround();
            this.lastSpawnPosition += this.spawnDistance;

        }
        // Destroy(this.gameObject, this.secondsBeforeDelete);

    }

    private void SpawnGround()
    {
        GameObject newGround = Instantiate(groundPrefab, this.groundPrefab.transform);
        newGround.transform.SetParent(this.grid.transform);
        newGround.transform.localScale = new Vector3(0.4488856f, 0.6523f, 0);
        newGround.transform.position = new Vector3(this.lastSpawnPosition + this.spawnDistance, -2.73f, 60.0f);
    }
}
