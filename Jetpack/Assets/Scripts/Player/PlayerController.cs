using Fish;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// A script containing the information for the player.
    /// <remarks>Coded by William.</remarks>
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
        public void UpdateScore(FishType type)
        {
            Debug.Log($"Type: {type}");  // TODO: Remove in production.
            this._score++;
        }
        /// <summary>
        /// End Game and GetScore
        /// </summary>
        public void EndGame()
        {
            // change this later to a screen that goes high score scene
            Debug.Log("Game has ended\nThank you for playing\n" + "Score: " + this.GetScore());
            // UnityEditor.EditorApplication.isPlaying = false;
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
