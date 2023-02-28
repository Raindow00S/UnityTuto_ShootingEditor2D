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
        }

        private void Start()
        {
            mRigidbody2D.velocity = Vector2.right * mSpeed;
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