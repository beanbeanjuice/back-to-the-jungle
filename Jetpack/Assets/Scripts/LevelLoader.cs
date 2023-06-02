using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A class used to animate the transitions between scenes.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float crossFadeTransitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // TODO: In production, remove this and replace with UI buttons.
        if (Input.GetKey("a"))
            LoadGameScene();

        if (Input.GetKey("d"))
            LoadDummyScene();
    }

    /// <summary>
    /// Call this class to load the gameplay scene.
    /// </summary>
    public void LoadGameScene()
    {
        StartCoroutine(LoadLevel("Gameplay", this.crossFadeTransitionTime));
    }

    /// <summary>
    /// Call this class to load the dummy scene.
    /// </summary>
    public void LoadDummyScene()
    {
        StartCoroutine(LoadLevel("Dummy Scene 1", this.crossFadeTransitionTime));
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
        this.transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene.
        SceneManager.LoadScene(sceneName);
    }
}
