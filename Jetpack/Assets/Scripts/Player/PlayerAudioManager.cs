using UnityEngine;
using Player;

/// <summary>
/// Class used to play wing flapping and walking SFX.
/// <remarks>Coded by Westley.</remarks>
/// </summary>
public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource walkFast;
    [SerializeField] private AudioSource wingFlap;
    private PlayerMovementController _parentController;
    private bool _isWalkingSFX = false;
    
    void Start()
    {
        this._parentController = GameObject.FindWithTag("Player").GetComponent<PlayerMovementController>();
    }
    
    private void Update()
    {
        // Uses GetButtonDown to ensure SFX is not spammed.
        if (Input.GetButtonDown("Jump")) wingFlap.Play();

        // Checks to play walking SFX.
        if (this._parentController.IsGrounded())
        {
            if (!_isWalkingSFX)
            {
                Debug.Log("groundSFX!");
                PlayWalkingSFX();
            }
        }
        else
        {
            StopWalkingSFX(); 
        }
    }

    private void PlayWalkingSFX()
    {
        walkFast.Play();
        this._isWalkingSFX = true;
    }

    private void StopWalkingSFX()
    {
        walkFast.Stop();
        this._isWalkingSFX = false;
    }
}
