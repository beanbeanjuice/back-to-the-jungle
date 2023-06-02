using Fish;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// A class used solely for collisions with enemies/game objects
    /// other than the floor.
    /// </summary>
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField] private AudioSource collectionSoundEffect;

        private PlayerController _pc;

        private void Start()
        {
            this._pc = GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Fish"))
            {
                this.collectionSoundEffect.Play();
                this._pc.UpdateScore(other.GetComponent<FishController>().GetFishType());
                Destroy(other.gameObject);
            }
        }
    }
}
