using UnityEngine;

namespace Fish
{
    public class FishController : MonoBehaviour
    {
        [SerializeField] private FishType type;
        [SerializeField] private FishBindings fishBindings;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            this._spriteRenderer = GetComponent<SpriteRenderer>();
            ChangeType(this.type);
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

    }
}
