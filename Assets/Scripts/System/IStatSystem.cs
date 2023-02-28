using FrameworkDesign;

namespace ShootingEditor2D
{
    /// <summary>
    /// 数据统计系统
    /// </summary>
    public interface IStatSystem : ISystem
    {
        BindableProperty<int> KillCount { get; }
    }

    public class StatSystem : AbstractSystem, IStatSystem
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() {Value = 0};
        
        protected override void OnInit()
        {
            
        }
    }
}