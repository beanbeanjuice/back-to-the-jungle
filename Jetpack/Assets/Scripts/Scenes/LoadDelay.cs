using System;
using UnityEngine;

namespace Scenes
{
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

        protected virtual void Logic() { }
    }
}
