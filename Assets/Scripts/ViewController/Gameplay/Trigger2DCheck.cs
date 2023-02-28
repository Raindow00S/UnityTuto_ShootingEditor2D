using System;
using UnityEngine;

namespace ShootingEditor2D
{
    /// <summary>
    /// 通用2D Trigger
    /// </summary>
    public class Trigger2DCheck : MonoBehaviour
    {
        public LayerMask TargetLayers;  // 一个mask是对多个layer的指示
        public int EnterCount;

        public bool Triggered
        {
            get { return EnterCount > 0; }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsInLayerMask(other.gameObject, TargetLayers))
                EnterCount++;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsInLayerMask(other.gameObject, TargetLayers))
                EnterCount--;
        }

        bool IsInLayerMask(GameObject obj, LayerMask mask)
        {
            var objLayerMask = 1 << obj.layer;
            return (mask & objLayerMask) > 0;
        }
    }
}