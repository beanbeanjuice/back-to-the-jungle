using UnityEngine;

public class BackgroundReplicator : MonoBehaviour
{
    public GameObject cam;
    //public float parallaxEffect;
    private float length, startpos;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
        float temp = cam.transform.position.x; // * (1 - parallaxEffect);
        // float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if(temp < startpos - length) 
        {
            startpos -= length;
        }
    }
}