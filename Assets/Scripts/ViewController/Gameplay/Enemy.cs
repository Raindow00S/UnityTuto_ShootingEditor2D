using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D mRigidBody2D;
        private Trigger2DCheck mWallCheck;
        private Trigger2DCheck mGroundCheck;
        private Trigger2DCheck mFallCheck;

        private float mSpeed = 6f;

        private void Start()
        {
            mRigidBody2D = GetComponent<Rigidbody2D>();
            mWallCheck = transform.Find("WallCheck").GetComponent<Trigger2DCheck>();
            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
            mFallCheck = transform.Find("FallCheck").GetComponent<Trigger2DCheck>();
        }

        private void Update()
        {
            var isRight = transform.localScale.x;

            // 前方没有墙、在地面上、不会落下
            if (!mWallCheck.Triggered && mGroundCheck.Triggered && mFallCheck.Triggered)
            {
                mRigidBody2D.velocity = new Vector2(mSpeed * isRight, mRigidBody2D.velocity.y);
            }
            // 否则转向
            else
            {
                var crtScale = transform.localScale;
                crtScale.x = -crtScale.x;
                transform.localScale = crtScale;
            }
        }
    }
}