using System;
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
            if (Input.GetButton("Jump"))  // TODO: Left click as well?
            {
                _rb.velocity = new Vector3(0, jumpVelocity, 0);
            }

            // Cancels and Rotation
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
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
