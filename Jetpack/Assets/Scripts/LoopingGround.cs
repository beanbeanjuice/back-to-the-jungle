using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    public GameObject groundPrefab;
    private Transform groundTransform;
    private Transform playerTransform;
    private float groundLength = 94.53f;
    private int groundTilesOnScreen = 1;
    private float spawnX = 94.53f;

    private void Start()
    {
        this.groundTransform = GameObject.FindGameObjectWithTag("GroundManager").transform;
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnGround();
        
    }

    private void Update()
    {
        if (playerTransform.position.x > (this.spawnX - groundTilesOnScreen * groundLength))
        {
            // Debug.Log(playerTransform.position.x + " > (" + spawnX + " - " + groundTilesOnScreen + " * " + groundLength + ")");
            Debug.Log("During Update, spawnX = " + this.spawnX);
            SpawnGround();
        }
    }

    private void SpawnGround()
    {
        GameObject ground;
        ground = Instantiate(this.groundPrefab) as GameObject;
        ground.transform.SetParent(this.groundTransform);
        ground.transform.position = new Vector2(this.spawnX,this.groundPrefab.transform.position.y);
        this.spawnX += this.groundLength;
        Debug.Log("After addition of groundLength, spawnX = " + this.spawnX);
    }
}