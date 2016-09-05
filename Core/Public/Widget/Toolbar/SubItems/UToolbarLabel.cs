using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbarLabel : ULabelBase
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public UToolbarLabel(string text)
        : base(EditorStyles.toolbarTextField)
    {
        _autoSize = false;
        _caption = text;
    }

    #endregion
}
