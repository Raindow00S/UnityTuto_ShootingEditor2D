using System;
using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour, IController
    {
        private GunInfo mGunInfo;
        private Bullet mBullet;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
            mGunInfo = this.GetSystem<IGunSystem>().CrtGun;
        }

        public void Shoot()
        {
            if (mGunInfo.BulletCountInGun.Value > 0)
            {
                var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
                bullet.transform.localScale = mBullet.transform.lossyScale; // 全局缩放值
                bullet.gameObject.SetActive(true);
                
                this.SendCommand<ShootCommand>(ShootCommand.Single);    // tip 命令模式优化，因为没有参数，所以重复使用一个全局的命令即可
            }
        }
        
        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }

        private void OnDestroy()
        {
            mGunInfo = null;
        }
    }
}