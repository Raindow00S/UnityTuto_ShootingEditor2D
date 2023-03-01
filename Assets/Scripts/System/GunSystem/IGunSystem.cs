using FrameworkDesign;

namespace ShootingEditor2D
{
    public interface IGunSystem : ISystem
    {
        GunInfo CrtGun { get; }
    }

    public class GunSystem : AbstractSystem, IGunSystem
    {
        public GunInfo CrtGun { get; } = new GunInfo()
        {
            BulletCount = new BindableProperty<int>() {Value = 3}
        };

        protected override void OnInit()
        {
            
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}