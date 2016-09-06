using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbarButton : UButton
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToolbarButton(string caption)
        : base(caption, EditorStyles.toolbarButton)
    {
        _autoSize = false;
    }

    #endregion
}
