﻿using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToolbarIntPopup : UIntPopup
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    public UToolbarIntPopup(int initValue, int[] values, string[] texts)
        : base(initValue, values, texts, EditorStyles.toolbarPopup)
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    public UToolbarIntPopup(string caption, int initValue, int[] values, string[] texts)
        : base(caption, initValue, values, texts, EditorStyles.toolbarPopup)
    {

    }

    #endregion
}
