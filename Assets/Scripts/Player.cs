using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRigidbody2D;
        private float mSpeed = 7f;  // todo 设置读写权限
        
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()  // tip 在update里移动可能会穿透
        {
            var horizontalInput = Input.GetAxis("Horizontal");

            mRigidbody2D.velocity = new Vector2(horizontalInput * mSpeed, mRigidbody2D.velocity.y);
        }
    }   
}
