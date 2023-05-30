using UnityEngine;

public class BackgroundReplicator : MonoBehaviour
{
    public GameObject camera;
    private float length, startPosition;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = camera.transform.position.x; 
        transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if(temp < startPosition - length) 
        {
            startPosition -= length;
        }
    }
}
