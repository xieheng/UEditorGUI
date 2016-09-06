using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class ULabel: UWidget
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public ULabel(string text)
    {
        _caption = text;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (!_visible)
            return;

        GUI.color = _color;
        {
            GUILayout.Label(_caption);
        }
        GUI.color = Color.white;
    }

    #endregion
}
