using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float acceleration;
        [SerializeField] private float jumpVelocity;

        private Rigidbody2D _rb;

        // Start is called before the first frame update
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
            if (Input.GetButton("Jump")) // TODO: Left click as well?
                _rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        }

        private void SetPlayerVelocity()
        {
            float yVelocity = this._rb.velocity.y;
            this.velocity += this.acceleration * Time.deltaTime;
            this._rb.velocity = new Vector2(this.velocity, yVelocity);
        }

        void LateUpdate()
        {
            //Vector2 currentPosition = this.transform.position;
            //this.velocity += this.acceleration * Time.fixedDeltaTime;
            //currentPosition.x += this.velocity * Time.deltaTime;


            //this.transform.position += (Vector3)currentPosition;
        }

    }
}
