using UnityEngine;

namespace Fish
{
    /// <summary>
    /// Controls the type and attributes of the fish object.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class FishController : MonoBehaviour
    {
        [SerializeField] private FishType type;
        [SerializeField] private FishBindings fishBindings;
        [SerializeField] private float deletionTime;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            this._spriteRenderer = GetComponent<SpriteRenderer>();
            ChangeType(this.type);

            /*
             * We need to destroy the fish after a certain amount of time
             * so that there aren't hundreds of random game objects that
             * are impossible to collect once the player passes them.
             */
            Destroy(this.gameObject, this.deletionTime);
        }

        /// <summary>
        /// Change the type of the fish.
        /// </summary>
        /// <param name="newType">The new type to set the fish to.</param>
        public void ChangeType(FishType newType)
        {
            this.type = newType;
            this._spriteRenderer.sprite = this.fishBindings.GetFishSprite(this.type);
        }

        /// <summary>
        /// Get the type of the current fish.
        /// </summary>
        /// <returns>The current fish type.</returns>
        public FishType GetFishType()
        {
            return this.type;
        }
    }
}
