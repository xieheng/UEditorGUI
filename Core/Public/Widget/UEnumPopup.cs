using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// 
/// </summary>
public class UEnumPopup : UWidget
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
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UEnumPopup(GUIStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UEnumPopup(string caption, GUIStyle style)
    {
        _caption = caption;
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
            EditorGUI.BeginChangeCheck();
            {
                _enum = EditorGUILayout.EnumPopup(_caption, _enum, _style);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }
        GUI.color = Color.white;
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
