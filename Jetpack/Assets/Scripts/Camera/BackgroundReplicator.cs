using UnityEngine;

/// <summary>
/// BackgroundReplicator moves the background once camera position passes its bounds,
/// replicating it for an endless scroll effect.
/// </summary>
public class BackgroundReplicator : MonoBehaviour
{
    [SerializedField] private GameObject cam;
    private float length;
    private float startPosition;

    private void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = cam.transform.position.x;
        transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);

        // If camera position exceeds bounds, add background.
        if (temp > startPosition + length)
            startPosition += length;
    }
}
