using UnityEngine;

namespace Player
{
    /// <summary>
    /// A class used solely for collisions with enemies/game objects
    /// other than the floor.
    /// </summary>
    public class PlayerCollisionController : MonoBehaviour
    {
        private PlayerController _pc;

        private void Start()
        {
            this._pc = GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Fish"))
            {
                Destroy(other.gameObject);
                this._pc.UpdateScore();
            }
        }
    }
}
