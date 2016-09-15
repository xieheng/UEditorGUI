using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UFlexibleSpace : UControl
{
    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        GUILayout.FlexibleSpace();
    }

    #endregion
}