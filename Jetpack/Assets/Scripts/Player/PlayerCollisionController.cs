using Fish;
using UnityEngine;
using TMPro;

namespace Player
{
    /// <summary>
    /// A class used solely for collisions with enemies/game objects
    /// other than the floor.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField] private AudioSource collectionSoundEffect;
        [SerializeField] private TextMeshProUGUI endDistanceTraveled;

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
                    // TODO: Play bird collision audio.
                    // TODO: Implement death/game over.
                    this.endDistanceTraveled.text = this._pc.GetDistanceRun().ToString("0");
                    Destroy(other.gameObject);
                    break;
                case "Vine":
                    // TODO: Play vine collision audio.
                    // TODO: Implement death/game over. It is possible to combine Bird and Vine in code depending on implementation.
                    this.endDistanceTraveled.text = this._pc.GetDistanceRun().ToString("0");
                    Destroy(other.gameObject);
                    break;
            }
        }
    }
}
