using System;
using UnityEngine;

namespace Ground
{
    public class GroundRepeater : MonoBehaviour
    {

        private BoxCollider2D _boxCollider;
        private Rigidbody2D _rb;
        private float _width;
        private float speed;

        private void Start()
        {
            this._boxCollider = GetComponent<BoxCollider2D>();
            this._rb = GetComponent<Rigidbody2D>();
            this._width = this._boxCollider.size.x;
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

    }
}
