using UnityEngine;

namespace Player
{
    /// <summary>
    /// A script containing the information for the player.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        private float _startX;
        private float _currentX;
        private int _score = 0;

        private void Start()
        {
            this._startX = this.transform.position.x;
        }

        private void Update()
        {
            this._currentX = this.transform.position.x;
        }

        /// <summary>
        /// Get the distance run for the player.
        /// </summary>
        /// <returns>The distance run in units.</returns>
        public float GetDistanceRun()
        {
            return this._currentX - this._startX;
        }

        /// <summary>
        /// Update the player's score.
        /// </summary>
        public void UpdateScore()
        {
            this._score++;
        }

        /// <summary>
        /// Get the player's current score.
        /// </summary>
        /// <returns>The current score as an int.</returns>
        public int GetScore()
        {
            return this._score;
        }
    }
}
