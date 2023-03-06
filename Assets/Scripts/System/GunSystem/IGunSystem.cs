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
            BulletCountInGun = new BindableProperty<int>() {Value = 3},
            Name = new BindableProperty<string>() {Value = "手枪"},
            GunState = new BindableProperty<GunState>() {Value = GunState.Idle},
            BulletCountOutGun = new BindableProperty<int>(){Value = 1}
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