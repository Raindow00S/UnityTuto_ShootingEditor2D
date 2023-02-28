using FrameworkDesign;

namespace ShootingEditor2D
{
    /// <summary>
    /// 玩家数据模型
    /// </summary>
    public interface IPlayerModel : IModel
    {
        BindableProperty<int> HP { get; }
    }

    public class PlayerModel : AbstractModel, IPlayerModel
    {
        public BindableProperty<int> HP { get; } = new BindableProperty<int>() {Value = 3};
        
        protected override void OnInit()
        {
            
        }
    }
}