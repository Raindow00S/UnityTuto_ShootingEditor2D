using System;
using FrameworkDesign;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace ShootingEditor2D
{
    public class UIController : MonoBehaviour, IController
    {
        private IPlayerModel mPlayerModel;
        private IStatSystem mStatSystem;
        private IGunSystem mGunSystem;

        private void Awake()
        {
            mPlayerModel = this.GetModel<IPlayerModel>();
            mStatSystem = this.GetSystem<IStatSystem>();
            mGunSystem = this.GetSystem<IGunSystem>();
        }

        // tip 懒加载，第一次调用OnGUI时才初始化GUIStyle，不能在生命周期的其他时候初始化（？）
        private readonly Lazy<GUIStyle> mLabelStyle = new Lazy<GUIStyle>(() =>
        {
            return new GUIStyle(GUI.skin.label)
            {
                fontSize = 40
            };
        });
        
        // tip unity自带的最早的UI，效率低，但是写起来快
        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 300, 100), $"生命：{mPlayerModel.HP.Value} / 3",
                mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"击杀：{mStatSystem.KillCount.Value}",
                mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 60, 300, 100), $"枪内子弹：{mGunSystem.CrtGun.BulletCountInGun.Value}",
                mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 110, 300, 100), $"枪外子弹：{mGunSystem.CrtGun.BulletCountOutGun.Value}",
                mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 160, 300, 100), $"枪状态：{mGunSystem.CrtGun.GunState.Value}",
                mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 210, 300, 100), $"枪名字：{mGunSystem.CrtGun.Name.Value}",
                mLabelStyle.Value);
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }

        private void OnDestroy()
        {
            mPlayerModel = null;
            mGunSystem = null;
            mStatSystem = null;
        }
    }
}