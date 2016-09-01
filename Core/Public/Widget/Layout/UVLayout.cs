using UnityEngine;
using UnityEditor;

public class UVLayout : ULayout
{
    /// <summary>
    /// 
    /// </summary>
    protected override void BeginGUI()
    {
        EditorGUILayout.BeginVertical();
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void EndGUI()
    {
        EditorGUILayout.EndVertical();
    }
}
