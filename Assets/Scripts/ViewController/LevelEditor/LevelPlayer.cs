using System;
using System.Xml;
using UnityEngine;

namespace ShootingEditor2D
{
    /// <summary>
    /// 关卡文件解析器
    /// </summary>
    public class LevelPlayer : MonoBehaviour
    {
        public TextAsset LevelFile;

        // 解析关卡文件，生成对应prefab
        private void Start()
        {
            var xml = LevelFile.text;
            var document = new XmlDocument();
            document.LoadXml(xml);

            var levelNode = document.SelectSingleNode("Level");
            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
                var levelItemName = levelItemNode.Attributes["name"].Value;
                var levelItemX = int.Parse(levelItemNode.Attributes["x"].Value);
                var levelItemY = int.Parse(levelItemNode.Attributes["y"].Value);

                var levelItemPrefab = Resources.Load<GameObject>(levelItemName);
                var levelItemGO = Instantiate(levelItemPrefab, transform);
                levelItemGO.transform.position = new Vector3(levelItemX, levelItemY, 0f);
                Debug.Log($"{levelItemName}: ({levelItemX}, {levelItemY})");
            }
        }
    }
}