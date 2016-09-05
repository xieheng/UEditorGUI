using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class ULabelBase : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GUIStyle _style = GUIStyle.none;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    protected ULabelBase()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected ULabelBase(GUIStyle style)
    {
        _style = style;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        GUI.color = _color;
        {
            GUILayout.Label(_caption, _style);
        }
        GUI.color = Color.white;
    }

    #endregion
}
