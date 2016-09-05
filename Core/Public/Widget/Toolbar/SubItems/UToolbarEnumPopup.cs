using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// 
/// </summary>
public class UToolbarEnumPopup : UEnumPopupBase
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enumValue"></param>
    public UToolbarEnumPopup(System.Enum enumValue)
        : base(EditorStyles.toolbarPopup)
    {
        _enum = enumValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enumValue"></param>
    public UToolbarEnumPopup(string caption, System.Enum enumValue)
        : base(EditorStyles.toolbarPopup)
    {
        _caption = caption;
        _enum = enumValue;
    }

    #endregion
}
