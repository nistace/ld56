using System;
using System.Linq;
using NiUtils.Extensions;
using UnityEditor;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [Serializable] protected class PrefabPerColor
    {
        [SerializeField] protected Color color;
        [SerializeField] protected Transform prefab;
        [SerializeField] protected Transform parent;

        public Color Color => color;
        public Transform Prefab => prefab;
        public Transform Parent => parent;
    }

    [SerializeField] protected Texture2D texture;
    [SerializeField] protected PrefabPerColor[] prefabs;

    #if UNITY_EDITOR
    [ContextMenu("Build")] private void Build()
    {
        if (Application.isPlaying) return;
        foreach (var prefab in prefabs)
        {
            if (prefab.Parent) prefab.Parent.ClearChildren();
        }
        var offset = 0;

        for (var i = 0; i < texture.height; ++i)
        {
            var line = texture.GetPixels(0, i, texture.width, 1);

            if (line[0] == Color.red)
            {
                offset = i + 1;
            }
            else
            {
                var start = 0;

                while (start < line.Length)
                {
                    var color = line[start];

                    var end = start;
                    while (end < line.Length && line[end] == color)
                    {
                        end++;
                    }

                    end--;

                    var center = (start + end) / 2f;
                    var width = end - start + 1;

                    foreach (var prefabColor in prefabs.Where(t => t.Color == color))
                    {
                        var block = (Transform)PrefabUtility.InstantiatePrefab(prefabColor.Prefab);

                        block.SetParent(prefabColor.Parent);
                        block.transform.position = new Vector3(center, i - offset, 0);
                        block.localScale = new Vector3(width, 1, 1);
                    }

                    start = end + 1;
                }

            }
        }
    }
    #endif

}
