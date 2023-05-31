using UnityEngine;

namespace Player
{
    /// <summary>
    /// A class used solely for player movement.
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float acceleration;
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float groundJumpVelocity;
        [SerializeField] private float maxYValue;

        private Rigidbody2D _rb;
        private bool _touchingGround;
        private bool _touchingCeiling;

        private void Start()
        {
            this._rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckInput();
            CeilingCheck();
            SetPlayerXVelocity();

            // Cancels the rotation of the sprite.
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        private void CheckInput()
        {
            if (Input.GetButton("Jump"))
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
                if (this._touchingGround)
                    this._rb.velocity = new Vector2(0, this.groundJumpVelocity);
                else if (this._touchingCeiling)
                    RemoveUpwardsVelocity(this.transform.position);
                else
                    this._rb.AddForce(new Vector2(0, this.jumpVelocity), ForceMode2D.Impulse);
            }
        }

        private void SetPlayerXVelocity()
        {
            float yVelocity = this._rb.velocity.y;  // Grab old y velocity.
            this.velocity += this.acceleration * Time.deltaTime;  // Update new velocity.
            this._rb.velocity = new Vector2(this.velocity, yVelocity);  // Set new velocity.
        }

        private void CeilingCheck()
        {
            Vector3 position = this.transform.position;

            /*
             * If the player is touching the ceiling, we want there to be no "upwards" inertia
             * or force. Therefore, the upwards velocity should be 0.
             */
            if (position.y >= this.maxYValue)
            {
                RemoveUpwardsVelocity(position);
                this._touchingCeiling = true;
            }
            else
            {
                this._touchingCeiling = false;
            }
        }

        private void RemoveUpwardsVelocity(Vector3 position)
        {
            this.gameObject.transform.position = new Vector3(position.x, this.maxYValue, position.z);
            this._rb.velocity = new Vector2(0, 0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ground")) this._touchingGround = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ground")) this._touchingGround = false;
        }

    }
}
