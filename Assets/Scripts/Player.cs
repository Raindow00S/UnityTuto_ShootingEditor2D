using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRigidbody2D;
        private Trigger2DCheck mGroundCheck;
        private float mSpeed = 7f;  // todo 设置读写权限

        private bool mJumpPressed;
        
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
        }

        private void FixedUpdate()  // tip 在update里移动可能会穿透
        {
            // 水平移动
            var horizontalInput = Input.GetAxis("Horizontal");
            mRigidbody2D.velocity = new Vector2(horizontalInput * mSpeed, mRigidbody2D.velocity.y);

            // 跳跃（防止空中连跳）
            var grounded = mGroundCheck.Triggered;
            if (mJumpPressed && grounded)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, mSpeed);
            }

            mJumpPressed = false;
        }

        private void Update()   // tip 输入在update里处理
        {
            if (Input.GetKeyDown(KeyCode.K))
                mJumpPressed = true;

        }
    }   
}
