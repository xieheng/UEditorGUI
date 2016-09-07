using UnityEngine;
using UnityEditor;

public class UHLayout : ULayout
{
    /// <summary>
    /// 
    /// </summary>
    protected override void BeginGUI()
    {
        EditorGUILayout.BeginHorizontal();
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void EndGUI()
    {
        EditorGUILayout.EndHorizontal();
    }
}
