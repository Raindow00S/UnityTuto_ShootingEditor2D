using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class ShootingEditor2D : Architecture<ShootingEditor2D>
    {
        protected override void Init()
        {
            RegisterSystem<IStatSystem>(new StatSystem());
            RegisterSystem<IGunSystem>(new GunSystem());
            RegisterModel<IPlayerModel>(new PlayerModel());
        }
    }
}