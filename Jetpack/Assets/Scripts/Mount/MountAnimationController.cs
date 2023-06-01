using UnityEngine;
using Player;

namespace Mount
{
    /// <summary>
    /// A class used solely for mount animation movement.
    /// </summary>
    public class MountAnimationController : MonoBehaviour
    {
        private PlayerMovementController _parentController;
        private Animator _anim;
        private readonly static int Flying = Animator.StringToHash("flying");
        private readonly static int Walking = Animator.StringToHash("touching_ground");
        private bool _touchingGround;

        private void Start()
        {
            this._anim = GetComponent<Animator>();
            this._parentController = this.gameObject.transform.parent.gameObject
                .GetComponent<PlayerMovementController>();
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
                this._anim.SetBool(Flying, true);
            }
            else
                this._anim.SetBool(Flying, false);

            /* If player is not actively flying, then is either gliding or walking on the ground.
             * Walk animation will only play when player is detected touching the ground, so
             * we check if player is touching ground and set the appropriate animation conditions.
            */
            this._touchingGround = this._parentController.GetGroundState();
            if (this._touchingGround)
                this._anim.SetBool(Walking, true);
            else
                this._anim.SetBool(Walking, false);
        }
    }
}
