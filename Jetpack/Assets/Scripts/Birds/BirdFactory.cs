using UnityEngine;
using System.Collections;

/// <summary>
/// The bird factory. This class is used for generating
/// and spawning enemy birds in.
/// </summary> 

public class BirdFactory : MonoBehaviour
{
    [SerializeField] private GameObject warningPrefab;
    [SerializeField] private GameObject birdPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float cooldown;
    [SerializeField] private float distanceBeforeLevelChange;
    private float _cooldownTimer;
    private float _lastSpawnLocation;
    private float _frequency;
    private float _frequencyTimer;
    private float _secondsBeforeLaunch = 1.5f;
    private float _minFrequency = 10.0f;
    private float _maxFrequency = 20.0f;
    private int _possibleBirds = 1;
    private int _numOfBirds;

    private void Start()
    {
        this._frequency = this.GetFrequency();
    }
    private void Update()
    {
      /*
          There should be a cooldown after every bird. So that we don't spawn
          birds every ten seconds

          Each time we spawn a bird, we want our frequency timer to change. This
          frequency timer will range between 10 and 20 seconds.

          In addition, we will have a delay after each Build so that we can get a
          safety net of at least 10 seconds. This way we don't have birds spawning
          every ten seconds because of our random range. 
      */
      this._cooldownTimer += Time.deltaTime;
      if (this._cooldownTimer > this.cooldown)
      {
          this._frequencyTimer += Time.deltaTime;
          if (this._frequencyTimer > _frequency)
          {
              this.Build();
              this._frequency = this.GetFrequency();
              this._frequencyTimer = 0;
              this._cooldownTimer = 0;
          }
      }
    }

    private void Build()
    {
        // add a range of difficulty later
        // as we get farther in-game, increase the possibility of receiving
        // more than one missile

        /*
            Instantiate our warning. We want to obtain the locked position of the warning
            to use for the y position of the bird. But we want to grab the y position, after
            we lock the warning movement.
              To do this, we need to know how long to wait after the warning object has been
              instantiated. We need to get the variable secondsBeforeLock in WarningController
              and call an invoke method to wait for certain amount of seconds before we
              obtain the correct y position
        */
        if (this.player.transform.position.x / this.distanceBeforeLevelChange >= 1 )
        {
            this._possibleBirds += 1;
            this._numOfBirds = Random.Range(1, this._possibleBirds);
        }
        for (int i = 0; i < this._numOfBirds; i++)
        {
            Debug.Log("Spawn bird");
            StartCoroutine(this.DelayBetweenBirds(4.5f));
            this.SpawnWarning();
        }
    }
    private void SpawnWarning()
    {
        GameObject warning = Instantiate(this.warningPrefab);
        float secondsBeforeLock = warning.GetComponent<WarningController>().GetSecondsBeforeLocking();
        StartCoroutine(this.WaitAndGetYPosition(secondsBeforeLock, warning));
        warning.GetComponent<WarningController>().DestroyWarning();
    }
    private IEnumerator WaitAndGetYPosition(float waitTime, GameObject warning)
    {
        yield return new WaitForSeconds(waitTime);
        this._lastSpawnLocation = warning.GetComponent<WarningController>().GetLastYPosition();
        yield return new WaitForSeconds(this._secondsBeforeLaunch);
        this.SpawnBird();
    }
    private void SpawnBird()
    {
        GameObject bird = Instantiate(this.birdPrefab);
        bird.GetComponent<BirdController>().SetBirdPosition(this._lastSpawnLocation);
        bird.GetComponent<BirdController>().DestroyBird();
    }
    private float GetFrequency()
    {
        return Random.Range(this._minFrequency, this._maxFrequency);
    }
    private IEnumerator DelayBetweenBirds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}