using FrameworkDesign;
using UnityEngine.SceneManagement;

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
            var playerModel = this.GetModel<IPlayerModel>();
            playerModel.HP.Value -= mHurt;
            if (playerModel.HP.Value <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}