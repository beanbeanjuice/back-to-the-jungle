using UnityEngine;
using System;
using System.Collections;
public class WarningController : MonoBehaviour
{
    [SerializeField] private float secondsBeforeDelete;
    [SerializeField] private float offsetFromCamera;
    [SerializeField] private float secondsBeforeLock;
    private GameObject _camera;
    private GameObject _player;
    private float _lastYPos;
    private float _warningTimer;
    private bool _isLocked;

    private void Awake()
    {
        this._camera = GameObject.FindGameObjectWithTag("MainCamera");
        this._player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.transform.position = this.GetWarningPosition();
        this._isLocked = false;
    }
    private void Update()
    {
        this._warningTimer += Time.deltaTime;
        if (this._warningTimer < this.secondsBeforeLock)
        {
            this.gameObject.transform.position = this.GetWarningPosition();
        }
        else
        {

            this._isLocked = true;
            this._lastYPos = this.gameObject.transform.position.y;
            this.gameObject.transform.position = this.GetWarningPosition();
        }
    }
    private Vector3 GetWarningPosition()
    {
        float xPos = this._camera.transform.position.x + this.offsetFromCamera;
        float yPos = 0.0f;
        if (this._isLocked)
        {
            yPos = this.gameObject.transform.position.y;
        }
        else
        {
            yPos = this._player.transform.position.y;
        }  
        float zPos = this._player.transform.position.z;
        Vector3 warningPos = new Vector3(xPos, yPos, zPos);
        return warningPos;
    }
    public void DestroyWarning()
    {
        Destroy(this.gameObject, this.secondsBeforeDelete);
    }
    public float GetLastYPosition()
    {
        return this._lastYPos;
    }
    public float GetSecondsBeforeLocking()
    {
        return this.secondsBeforeLock;
    }
}