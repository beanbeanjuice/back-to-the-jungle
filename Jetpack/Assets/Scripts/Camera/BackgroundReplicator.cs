using UnityEngine;

/// <summary>
/// BackgroundReplicator moves the background once camera position passes its bounds,
/// replicating it for an endless scroll effect.
/// </summary>

namespace Camera
{
    public class BackgroundReplicator : MonoBehaviour
    {
        [SerializeField] private GameObject cam;
        private float _length;
        private float _startPosition;

        private void Start()
        {
            this._startPosition = transform.position.x;
            this._length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            float temp = cam.transform.position.x;
            transform.position = new Vector3(_startPosition, transform.position.y, transform.position.z);

            // If camera position exceeds bounds, add background.
            if (temp > this._startPosition + this._length)
                this._startPosition += this._length;
        }
    }
}
