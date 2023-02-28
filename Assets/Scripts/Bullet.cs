using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D mRigidbody2D;
        private float mSpeed = 10f;
        
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            mRigidbody2D.velocity = Vector2.right * mSpeed;
        }
    }
}