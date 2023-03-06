using System;
using FrameworkDesign;

namespace ShootingEditor2D
{
    public class GunInfo
    {
        public BindableProperty<int> BulletCountInGun;
        public BindableProperty<string> Name;
        public BindableProperty<GunState> GunState;
        public BindableProperty<int> BulletCountOutGun;
    }

    public enum GunState
    {
        Idle, Shooting, Reload, EmptyBullet, CoolDown
    }
}