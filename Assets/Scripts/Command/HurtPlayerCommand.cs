using FrameworkDesign;

namespace ShootingEditor2D
{
    /// <summary>
    /// 玩家受击
    /// </summary>
    public class HurtPlayerCommand : AbstractCommand
    {
        private readonly int mHurt;

        public HurtPlayerCommand(int hurt = 1)
        {
            mHurt = hurt;
        }
        
        protected override void OnExecute()
        {
            this.GetModel<IPlayerModel>().HP.Value -= mHurt;
        }
    }
}