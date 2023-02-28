using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour
    {
        private Bullet mBullet;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
        }

        public void Shoot()
        {
            var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
            bullet.transform.localScale = mBullet.transform.lossyScale; // 全局缩放值
            bullet.gameObject.SetActive(true);
        }
    }
}