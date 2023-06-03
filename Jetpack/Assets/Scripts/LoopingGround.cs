using UnityEngine;

/// <summary>
/// Looping Ground. This class is used for generating and spawning ground in.
/// </summary>
public class LoopingGround : MonoBehaviour
{
    [SerializeField] public GameObject currentGround;
    [SerializeField] public GameObject nextGround;
    [SerializeField] private GameObject grid;
    [SerializeField] private float spawnDistance; // ground length
    [SerializeField] private GameObject player;
    private float _endOfGround;
    private bool _onCurrent = true;
    private void Start()
    {
        this._endOfGround = this.currentGround.transform.position.x + this.spawnDistance;
    }

    private void Update()
    {
        float playerPosition = this.player.transform.position.x;
        if (playerPosition > this._endOfGround)
        {
            SwitchGround();
        }
    }
    private void SwitchGround()
    {
        // Switch between grounds here. If we are on the GameObject currentGround prepare the GameObject nextGround to move forward
        if (this._onCurrent)
        {
            // Dimensions used here are from sprites used in game.
            this._endOfGround = this.nextGround.transform.position.x + this.spawnDistance;
            this.currentGround.transform.position = new Vector3(this._endOfGround, -2.73f, 60.0f);
            this._onCurrent = false;
        }
        else
        {
            this._endOfGround = this.currentGround.transform.position.x + this.spawnDistance;
            this.nextGround.transform.position = new Vector3(this._endOfGround, -2.73f, 60.0f);
            this._onCurrent = true;
        }
    }
}
