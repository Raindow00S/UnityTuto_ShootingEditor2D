using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class UIGameStart : MonoBehaviour
    {
        private readonly Lazy<GUIStyle> mLabelStyle = new Lazy<GUIStyle>(() => new GUIStyle()
        {
            fontSize = 80,
            alignment = TextAnchor.MiddleCenter
        });

        private readonly Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() => new GUIStyle()
        {
            fontSize = 40,
            alignment = TextAnchor.MiddleCenter
        });


        private void OnGUI()
        {
            var labelRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, Screen.height * 0.5f, 400, 100);
            GUI.Label(labelRect, $"ShootingEditor2D", mLabelStyle.Value);
            
            var btnRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, Screen.height * 0.5f + 150f, 200, 100);
            if (GUI.Button(btnRect, "开始游戏", mButtonStyle.Value))
            {
                SceneManager.LoadScene("SampleScene");
                Debug.Log("game start");
            }
        }
    }
}