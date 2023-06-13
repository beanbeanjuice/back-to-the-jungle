using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    /// <summary>
    /// A class to play the Egg animation.
    /// <remarks> Referenced from:
    /// https://www.youtube.com/watch?v=0soGRKtpJuA&ab_channel=TheGameDevShow</remarks>
    /// </summary>
    public class ShopMenu : MonoBehaviour 
    {
        void Start()
        {
            StartCoroutine(NextScene());
        }

        private IEnumerator NextScene()
        {
            yield return new WaitForSeconds(2.45f);
            SceneManager.LoadScene("ShopMenu");
        }
    }
}