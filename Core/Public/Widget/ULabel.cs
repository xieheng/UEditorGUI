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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="style"></param>
    protected ULabel(string text, GUIStyle style)
    {
        _caption = text;
        _style = style;
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
            if (_style == GUIStyle.none)
            {
                GUILayout.Label(_caption);
            }
            else
            {
                GUILayout.Label(_caption, _style);
            }
        }
        GUI.color = Color.white;
    }

    #endregion
}
