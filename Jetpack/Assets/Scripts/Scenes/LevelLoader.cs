using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    /// <summary>
    /// A class used to animate the transitions between scenes.
    /// <remarks>Coded by William and Emily.</remarks>
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private float crossFadeTransitionTime = 1.0f;

        private readonly static int Start = Animator.StringToHash("Start");

        /// <summary>
        /// Call this class to load the GameStartCutscene scene.
        /// </summary>
        public void LoadCutScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("GameStartCutscene", this.crossFadeTransitionTime));
        }

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

        /// <summary>
        /// Call this class to load ShopMenu scene.
        /// </summary>
        public void LoadShopMenuScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("ShopMenu", this.crossFadeTransitionTime));
        }

        /// <summary>
        /// Call this class to load SettingsMenu scene.
        /// </summary>
        public void LoadSettingsMenuScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("SettingsMenu", this.crossFadeTransitionTime));
        }

        /// <summary>
        /// Call this class to load HowToPlayScene scene.
        /// </summary>
        public void LoadHowToPlayScene()  // TODO: Change to private if not used in production.
        {
            StartCoroutine(LoadLevel("HowToPlayScene", this.crossFadeTransitionTime));
        }

        /// <summary>
        /// Call this to quit the game.
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
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
