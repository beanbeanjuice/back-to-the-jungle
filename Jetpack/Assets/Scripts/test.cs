using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private string sceneName;
    [SerializeField] private float delayTime = 3.0f;
    private readonly static int Start = Animator.StringToHash("Start");


    private float timeElapsed;

    private void Update()
    {
        if(sceneName == "StartMenu"){
            timeElapsed += Time.deltaTime;
            DelayLoad(sceneName, delayTime);
        }

    }
    public void DelayLoad(string sceneName, float delayTime)
    {
        // Play animation.
        this.transition.SetTrigger(Start);
        if(timeElapsed > delayTime)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ClickLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}