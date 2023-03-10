using System;
using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Bullet : MonoBehaviour, ICanSendCommand
    {
        private Rigidbody2D mRigidbody2D;
        private float mSpeed = 10f;
        
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            
            // 延时销毁
            Destroy(this, 5f);
        }

        private void Start()
        {
            var isRight = Mathf.Sign(transform.lossyScale.x);
            mRigidbody2D.velocity = Vector2.right * mSpeed * isRight;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                this.SendCommand<KillEnemyCommand>();
                
                Destroy(other.gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}