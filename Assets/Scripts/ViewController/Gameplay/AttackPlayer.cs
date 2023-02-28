using System;
using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    /// <summary>
    /// 能够对玩家造成碰撞伤害的
    /// </summary>
    public class AttackPlayer : MonoBehaviour, IController
    {
        public int Hurt = 1;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                this.SendCommand(new HurtPlayerCommand(Hurt));
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}