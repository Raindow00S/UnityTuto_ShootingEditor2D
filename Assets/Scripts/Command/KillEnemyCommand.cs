using FrameworkDesign;

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
        }
    }
}