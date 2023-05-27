using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float acceleration;
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float groundJumpVelocity;

        private Rigidbody2D _rb;
        private bool _touchingGround;

        void Start()
        {
            this._rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckInput();
            SetPlayerVelocity();

            // Cancels and Rotation
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
                 */
                if (this._touchingGround)
                    this._rb.velocity = new Vector2(0, this.groundJumpVelocity);
                else
                    this._rb.AddForce(new Vector2(0, this.jumpVelocity), ForceMode2D.Impulse);
            }
        }

        private void SetPlayerVelocity()
        {
            float yVelocity = this._rb.velocity.y;  // Grab old y velocity.
            this.velocity += this.acceleration * Time.deltaTime;  // Update new velocity.
            this._rb.velocity = new Vector2(this.velocity, yVelocity);  // Set new velocity.
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
