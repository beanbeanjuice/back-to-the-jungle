using UnityEngine;

/// <summary>
/// The vine factory. This class is used for generating
/// and spawning vines in.
/// </summary> 

public class VineFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] vinePrefabs;
    [SerializeField] private GameObject player;
    [SerializeField] private float threshold;
    [SerializeField] private float secondsBeforeDelete;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;
    [SerializeField] private int numOfVines;
    private float _lastSpawnLocation;
    private float _scale;

    private void Start()
    {
        this._lastSpawnLocation = this.player.transform.position.x + this.threshold;
    }
    
    private void Update()
    {
        int vineNum = Random.Range(0, 4);
        float playerPosition = this.player.transform.position.x;

        if (playerPosition > this._lastSpawnLocation)
        {
            PrepareVine(vineNum);
        }
    }

    private void PrepareVine(int vineNum)
    {
        GameObject vine = Instantiate(this.vinePrefabs[vineNum], transform);
        this._lastSpawnLocation += this.threshold;
        
        float positionY = 0.0f;
        int randInt = Random.Range(0,1);

        // Choose either 0.35 or 0.50 based on the random number
        if (randInt < this.maxScale)
        {
            this._scale = this.minScale;
            positionY = Random.Range(-2.77f, 3.75f);
        }
        else
        {
            this._scale = this.maxScale;
            positionY = Random.Range(-0.84f, 1.58f);
        }

        // depending on the scale of the vine, we want to make sure we place
        // the vine in the correct Y coordinate
        // at a scale size of 0.35, our y min bound is -2.77, max bound is 3.75
        // at a scale size of 0.5, our y min bound is -0.84, max bound is 1.58

        vine.transform.position = new Vector3(this._lastSpawnLocation, positionY, this.player.transform.position.z);
        vine.transform.localScale = new Vector3(this._scale, this._scale, 0.0f);

        Destroy(vine, this.secondsBeforeDelete);
    }
}

