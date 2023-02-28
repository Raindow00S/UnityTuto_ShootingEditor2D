using System;
using UnityEngine;

namespace ShootingEditor2D
{
    /// <summary>
    /// 简易相机跟随
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        private Transform mPlayerTrans;

        private void Update()
        {
            if (!mPlayerTrans)
            {
                var playerGO = GameObject.FindWithTag("Player");

                if (playerGO)
                {
                    mPlayerTrans = playerGO.transform;
                }
                else
                {
                    return;
                }
            }
            
            var cameraPos = transform.position;
            var playerPos = mPlayerTrans.position;
            cameraPos.x = playerPos.x + 3;
            cameraPos.y = playerPos.y + 2;

            transform.position = cameraPos;
        }
        
        
    }
}