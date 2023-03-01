using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRigidbody2D;
        private Trigger2DCheck mGroundCheck;
        private Gun mGun;
        
        private float mSpeed = 7f;  // todo 设置读写权限
        private float mJumpForce = 5f;

        private bool mJumpPressed;
        
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
            mGun = transform.Find("Gun").GetComponent<Gun>();
        }

        private void FixedUpdate()  // tip 在update里移动可能会穿透
        {
            // 水平移动
            var horizontalInput = Input.GetAxis("Horizontal");
            
            // 转向
            if (horizontalInput * transform.localScale.x < 0)
            {
                var tmpScale = transform.localScale;
                tmpScale.x *= (-1);
                transform.localScale = tmpScale;
            }
            
            mRigidbody2D.velocity = new Vector2(horizontalInput * mSpeed, mRigidbody2D.velocity.y);

            // 跳跃（防止空中连跳）
            var grounded = mGroundCheck.Triggered;
            if (mJumpPressed && grounded)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, mJumpForce);
            }

            mJumpPressed = false;
        }

        private void Update()   // tip 输入在update里处理
        {
            if (Input.GetKeyDown(KeyCode.Space))
                mJumpPressed = true;
            if(Input.GetKeyDown(KeyCode.S))
                mGun.Shoot();
        }
    }   
}
