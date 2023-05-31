using UnityEngine;

namespace Mount
{
    /// <summary>
    /// A class used solely for mount animation movement.
    /// </summary>
    public class MountAnimationController : MonoBehaviour
    {
        private Animator _anim;
        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetButton("Jump"))
            {
                /*
                 * If the player is flying upwards, we want to change the mount animation
                 * to flying instead of gliding.
                 */ 
                 _anim.SetBool("flying", true);
            }
            else
                _anim.SetBool("flying", false);
        }
    }
}
