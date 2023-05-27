using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float xOffset;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector2 playerPosition = this.player.transform.position;
            Vector3 cameraPosition = this.transform.position;

            Vector3 newCameraPosition = new Vector3(playerPosition.x + this.xOffset, cameraPosition.y, cameraPosition.z);

            // Setting the Camera Position
            this.transform.position = newCameraPosition;
        }
    }
}
