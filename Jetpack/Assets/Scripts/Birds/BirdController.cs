using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float secondsBeforeDelete;
    [SerializeField] private float xOffset;
    [SerializeField] private float xVelocity;
    private GameObject _camera;
    private GameObject _player;

    private void Awake()
    {
        this._camera = GameObject.FindGameObjectWithTag("MainCamera");
        this._player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        this.gameObject.transform.position += new Vector3(this.xVelocity * Time.deltaTime, 0);
    }
    public void SetBirdPosition(float yPos)
    {
        float xPos = this._camera.transform.position.x + this.xOffset;
        float zPos = this._player.transform.position.z;
        this.gameObject.transform.position = new Vector3(xPos, yPos, zPos);
    }
    public void DestroyBird()
    {
        Destroy(this.gameObject, this.secondsBeforeDelete);
    }
}