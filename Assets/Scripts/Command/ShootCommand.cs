using FrameworkDesign;

namespace ShootingEditor2D
{
    public class ShootCommand : AbstractCommand
    {
        public static readonly ShootCommand Single = new ShootCommand();
        
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            gunSystem.CrtGun.BulletCountInGun.Value--;
            gunSystem.CrtGun.GunState.Value = GunState.Shooting;
        }
    }
}