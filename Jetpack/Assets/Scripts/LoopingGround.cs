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

    // private float spawnY = -3.0f; // 2.368249

    private float lastSpawnPosition;

    private void Start()
    {
        this.lastSpawnPosition = groundPrefab.transform.position.x; // -15.7, -9.89

    }

    private void Update()
    {
        float playerPosition = player.transform.position.x;
        // lastSpawnPosition = -15.7
        // playerPosition = -9.89
        // spawnDistance = 40
        // 36
        if (playerPosition > (this.lastSpawnPosition + this.spawnDistance) / 2)
        {
            SpawnGround();
            lastSpawnPosition += spawnDistance;

        }
        // Destroy(this.gameObject, this.secondsBeforeDelete);

    }

    private void SpawnGround()
    {
        // Transform groundPos = new Vector2(lastSpawnPosition + spawnDistance, this.spawnY);
        // Transform groundTransform;
        // groundTransform.position = groundPos;
        // GameObject newGround = Instantiate(groundPrefab, new Vector3(lastSpawnPosition + spawnDistance, 0, 0), Quaternion.identity);
        // Transform myGround = this.groundPrefab.transform;
        // myGround.transform.position = new Vector3(lastSpawnPosition + spawnDistance, 0, 0);
        // newGround.transform.SetParent(myGround);
        GameObject newGround = Instantiate(groundPrefab, this.groundPrefab.transform);
        newGround.transform.SetParent(this.grid.transform);
        newGround.transform.localScale = new Vector3(0.4488856f, 0.6523f, 0);
        newGround.transform.position = new Vector3(lastSpawnPosition + spawnDistance, -2.73f, 60.0f);

        //0.4488856
        //0.6523
    }
}
