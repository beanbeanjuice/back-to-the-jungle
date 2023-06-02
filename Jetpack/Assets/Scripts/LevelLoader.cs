using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float crossfadeTransitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            LoadGameScene();
        }

        if (Input.GetKey("d"))
        {
            LoadDummyScene();
        }

    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadLevel("Gameplay", this.crossfadeTransitionTime));
    }

    public void LoadDummyScene()
    {
        StartCoroutine(LoadLevel("Dummy Scene 1", this.crossfadeTransitionTime));
    }

    IEnumerator LoadLevel(string sceneName, float transitionTime)
    {
        // Play animation.
        this.transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene.
        SceneManager.LoadScene(sceneName);
    }
}
