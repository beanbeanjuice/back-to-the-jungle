using UnityEngine;

namespace Player
{
    /// <summary>
    /// A class used solely for player movement.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float velocity = 5.0f;
        [SerializeField] private float acceleration = 0.04f;
        [SerializeField] private float flyForce = 75.0f;
        [SerializeField] private float jumpForce = 3.0f;
        [SerializeField] private float maxYValue = 4.5f;
        [SerializeField] private LayerMask walkingGround;
        private Rigidbody2D _rb;
        private BoxCollider2D _collider;
        private bool _touchingCeiling;

        private void Start()
        {
            this._rb = GetComponent<Rigidbody2D>();
            this._collider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            CeilingCheck();
            VelocityCheck();

            // Cancels the rotation of the sprite.
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        /*
         * Runs at a fixed time. This is needed because, depending on
         * hardware, could cause the player to fly really quickly.
         */
        private void FixedUpdate()
        {
            CheckInput();
            SetPlayerXVelocity();
        }

        private void CheckInput()
        {
            if (Input.GetButton("Jump"))  // TODO: Invert this in production if only use.
            {
                /*
                 * If the player is touching the ground, we want to add some sort of force
                 * to the player so that the jump feels instantaneous. This is so that the
                 * player's velocity does not start at 0 when they jump, but instead starts
                 * at some predetermined value.
                 *
                 * Additionally, if the player is touching the ceiling AND holding the jump
                 * button, then we want to keep their position at the top of the screen. If
                 * we do not do this, there will be some minor jumping that occurs.
                 */
                if (IsGrounded())
                    this._rb.velocity = new Vector2(0, this.jumpForce);
                else if (this._touchingCeiling)
                    RemoveUpwardsVelocity(this.transform.position);
                else
                    this._rb.AddForce(new Vector2(0, this.flyForce), ForceMode2D.Impulse);
            }
        }

        private void SetPlayerXVelocity()
        {
            /*
             * First, we want to grab the old y velocity, then
             * update the y velocity, then set the RigidBody's
             * y velocity to the updated y velocity.
             */
            float yVelocity = this._rb.velocity.y;
            this.velocity += this.acceleration * Time.deltaTime;
            this._rb.velocity = new Vector2(this.velocity, yVelocity);
        }

        private void CeilingCheck()
        {
            Vector3 position = this.transform.position;

            /*
             * If the player is touching the ceiling, we want there to be no "upwards" inertia
             * or force. Therefore, the upwards velocity should be 0.
             */
            this._touchingCeiling = (position.y >= this.maxYValue);
            if (this._touchingCeiling) RemoveUpwardsVelocity(position);
        }

        /// <summary>
        /// <remarks>Coded by Roxanne.</remarks>
        /// </summary>
        private void VelocityCheck()
        {
            /*
             * If the player mangages to reach velocity 18, we want to stop accelerating
             * so that the player maintains this speed and does go any faster.
             */
            if (this.velocity >= 15.0f)
            {
                this.velocity = 15.0f;
                this.acceleration = 0.0f;
            }
        }

        private void RemoveUpwardsVelocity(Vector3 position)
        {
            this.gameObject.transform.position = new Vector3(position.x, this.maxYValue, position.z);
            this._rb.velocity = new Vector2(0, 0);
        }

        /// <summary>
        /// Getter to get ground state to update mount animation in MountAnimationController.
        /// </summary>
        /// <remarks>Coded by Roxanne and William.</remarks>
        /// <returns>A boolean indicator of if player is touching ground.</returns>
        public bool IsGrounded()
        {
            /*
             * This essentially creates another box collider of the
             * same size, located at the same place, moves it down by 0.1f units
             * and checks if it is colliding with the ground.
             */
            Bounds boxBound = this._collider.bounds;
            return Physics2D.BoxCast(
                boxBound.center,
                boxBound.size,
                0f,
                Vector2.down,
                .1f,
                this.walkingGround
                );
        }
    }
}
