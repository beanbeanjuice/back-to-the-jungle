using System;
using UnityEngine;

namespace Scenes
{
    /// <summary>
    /// A class that adds an artificial delay
    /// before switching scenes.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public abstract class LoadDelay : MonoBehaviour
    {
        [SerializeField] private GameObject levelLoader;
        [SerializeField] private float loadDelay = 1.0f;

        protected LevelLoader LevelLoaderScript;
        private float _timer = 0;

        private void Start()
        {
            this.LevelLoaderScript = this.levelLoader.GetComponent<LevelLoader>();
        }

        private void Update()
        {
            this._timer += Time.deltaTime;
            if (this._timer < this.loadDelay) return;
            Logic();
        }

        /// <summary>
        /// A function that contains the actual logic for what happens
        /// when the timer is over.
        /// </summary>
        protected virtual void Logic() { }
    }
}
