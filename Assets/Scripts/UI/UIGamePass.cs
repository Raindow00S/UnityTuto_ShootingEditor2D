using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var labelWidth = 400;
        var labelHeight = 100;
        var labelPosition = new Vector2(Screen.width - labelWidth, Screen.height - labelHeight) * 0.5f;
        var labelSize = new Vector2(labelWidth, labelHeight);
        var labelRect = new Rect(labelPosition, labelSize);
        
        GUI.Label(labelRect,$"游戏通关",mLabelStyle.Value);

        var btnwidth = 200;
        var btnHeight = 100;
        var btnPos = new Vector2(Screen.width, Screen.height) * 0.5f -
                     new Vector2(btnwidth * 0.5f, btnHeight * 0.5f) - new Vector2(0f, 150f);
        var btnSize = new Vector2(btnwidth, btnHeight);
        var btnRect = new Rect(btnPos, btnSize);
        if (GUI.Button(btnRect, "返回首页", mButtonStyle.Value))
        {
            Debug.Log("return to home page");
        }
    }
}
