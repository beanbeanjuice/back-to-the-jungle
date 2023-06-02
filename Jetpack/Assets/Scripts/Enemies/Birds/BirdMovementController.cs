using UnityEngine;

namespace Enemies.Birds
{
    /// <summary>
    /// A class used for moving the birds on the scene.
    /// <remarks>Coded by William</remarks>
    /// </summary>
    public class BirdMovementController : MonoBehaviour
    {
        [SerializeField] private float xVelocity = -5.0f;  // TODO: Possibly change this dynamically as game gets harder.

        private void Update()
        {
            this.gameObject.transform.position += new Vector3(this.xVelocity * Time.deltaTime, 0);
        }
    }
}
