using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbarButton : UButtonBase
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToolbarButton(string caption)
        : base(EditorStyles.toolbarButton)
    {
        _autoSize = false;
        _caption = caption;
    }

    #endregion
}
