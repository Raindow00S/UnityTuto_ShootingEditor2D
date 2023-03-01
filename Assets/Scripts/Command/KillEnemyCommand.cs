using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    /// <summary>
    /// 击杀敌人
    /// </summary>
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetSystem<IStatSystem>().KillCount.Value++;
            
            // 随机补充子弹
            var randomIndex = Random.Range(0, 100);
            if (randomIndex < 80)
            {
                this.GetSystem<IGunSystem>().CrtGun.BulletCount.Value += Random.Range(1, 4);
            }
        }
    }
}