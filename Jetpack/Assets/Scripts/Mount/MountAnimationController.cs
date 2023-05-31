using UnityEngine;
using Player;

namespace Mount
{
    /// <summary>
    /// A class used solely for mount animation movement.
    /// </summary>
    public class MountAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        private Animator _anim;
        private bool _touchingGround;
        private void Start()
        {
            this._anim = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateState();
        }
        private void UpdateState()
        {
            if (Input.GetButton("Jump"))
            {
                /*
                 * If the player is flying upwards, we want to change the mount animation
                 * to flying instead of gliding. Otherwise, the player glides.
                 */ 
                 _anim.SetBool("flying", true);
            }
            else
                _anim.SetBool("flying", false);

            /* If player is not actively flying, then is either gliding or walking on the ground.
             * Walk animation will only play when player is detected touching the ground, so
             * we check if player is touching ground and set the appropriate animation conditions.
             */
            this._touchingGround = this._parent.GetComponent<PlayerMovementController>().GetGroundState();
            if (this._touchingGround)
                _anim.SetBool("touching_ground", true);
            else
                _anim.SetBool("touching_ground", false);
        }
    }
}
