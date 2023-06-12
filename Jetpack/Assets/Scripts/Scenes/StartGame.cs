using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    /// <summary>
    /// A class to transition out of lab cutscene into gameplay scene.
    /// <remarks> Referenced from:
    /// https://www.youtube.com/watch?v=0soGRKtpJuA&ab_channel=TheGameDevShow</remarks>
    /// </summary>
    public class StartGame : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(NextScene());
        }

        void Update()
        {

        }

        private IEnumerator NextScene()
        {
            yield return new WaitForSeconds(2.45f);
            SceneManager.LoadScene("Gameplay");
        }
    }
}
