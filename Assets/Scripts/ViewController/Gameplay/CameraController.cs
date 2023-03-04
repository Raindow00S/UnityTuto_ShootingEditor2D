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

        private float xMin = -5f;
        private float xMax = 5f;
        private float yMin = -5f;
        private float yMax = 5f;
        private Vector3 mTargetPos;

        private void LateUpdate()
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
            var isFacingRight = Mathf.Sign(mPlayerTrans.transform.localScale.x);
            mTargetPos.x = playerPos.x + 3 * isFacingRight;
            mTargetPos.y = playerPos.y + 2;
            mTargetPos.z = -10;
            
            // 平滑处理
            float smoothSpd = 5f;
            cameraPos = Vector3.Lerp(cameraPos, new Vector3(mTargetPos.x, mTargetPos.y, cameraPos.z),
                smoothSpd * Time.deltaTime);
            
            // 锁定在一个区域
            transform.position = new Vector3(Math.Clamp(cameraPos.x, xMin, xMax), 
                Math.Clamp(cameraPos.y, yMin, yMax),
                cameraPos.z);
        }
    }
}