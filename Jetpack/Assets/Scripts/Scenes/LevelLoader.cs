using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    /// <summary>
    /// A class used to animate the transitions between scenes.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private float crossFadeTransitionTime = 1.0f;

        private readonly static int Start = Animator.StringToHash("Start");

        /// <summary>
        /// Call this class to load the Gameplay scene.
        /// </summary>
        public void LoadGameScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("Gameplay", this.crossFadeTransitionTime));
        }

        /// <summary>
        /// Call this class to load StartMenu scene.
        /// </summary>
        public void LoadStartMenuScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("StartMenu", this.crossFadeTransitionTime));
        }

        /*
         * This is a private class, used to load any scene based on a
         * specified transition time, using the given animation.
         * This should work with any animation, any scene, given that
         * the proper functions are specified above.
         */
        private IEnumerator LoadLevel(string sceneName, float transitionTime)
        {
            // Play animation.
            this.transition.SetTrigger(Start);

            // Wait
            yield return new WaitForSeconds(transitionTime);

            // Load scene.
            SceneManager.LoadScene(sceneName);
        }
    }
}
