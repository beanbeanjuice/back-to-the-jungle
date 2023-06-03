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
        [SerializeField] private AudioSource endGameMusic;

        private PlayerController _pc;

        private void Start()
        {
            this._pc = GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Fish":
                    this.collectionSoundEffect.Play();
                    this._pc.UpdateScore(other.GetComponent<FishController>().GetFishType());
                    Destroy(other.gameObject);
                    break;
                case "Bird":
                    // TODO: Implement death/game over.
                    Destroy(other.gameObject);
                    break;
                case "Vine":
                    this.endGameMusic.Play();
                    this._pc.EndGame();
                    break;
            }
        }
    }
}
