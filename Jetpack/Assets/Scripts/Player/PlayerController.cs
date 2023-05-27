using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float acceleration;
        [SerializeField] private float jumpVelocity;

        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
            if (Input.GetButton("Jump")) _rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        }

        private void SetPlayerVelocity()
        {
            float yVelocity = this._rb.velocity.y;  // Grab old y velocity.
            this.velocity += this.acceleration * Time.deltaTime;  // Update new velocity.
            this._rb.velocity = new Vector2(this.velocity, yVelocity);  // Set new velocity.
        }

    }
}
