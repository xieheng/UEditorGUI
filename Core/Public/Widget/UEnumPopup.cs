using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// 
/// </summary>
public class UEnumPopup : UCaptionWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected System.Enum _enum = null;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UEnumChangedEventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UEnumPopup()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UEnumPopup(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UEnumPopup(GUIStyle style)
    {
        this.style = style;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UEnumPopup(string caption, GUIStyle style)
        : base(caption)
    {
        this.style = style;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    protected override void UpdateGUI()
    {
        EditorGUI.BeginChangeCheck();
        {
            _enum = EditorGUILayout.EnumPopup(caption, _enum, style);
        }
        bool changed = EditorGUI.EndChangeCheck();

        if (changed)
        {
            OnValueChangedHandler();
        }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnValueChangedHandler()
    {
        if (OnValueChanged != null)
        {
            UEnumEventArgs args = new UEnumEventArgs(this, _enum);
            OnValueChanged(args);
        }
    }

    #endregion
}
