using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class UIGamePass : MonoBehaviour
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
            GUI.Label(labelRect, $"游戏通关", mLabelStyle.Value);

            var btnRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, Screen.height * 0.5f + 150f, 200, 100);
            if (GUI.Button(btnRect, "回到首页", mButtonStyle.Value))
            {
                SceneManager.LoadScene("GameStart");
                Debug.Log("return to home page");
            }
        }
    }
}