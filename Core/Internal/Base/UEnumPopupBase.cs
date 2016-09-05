using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// 
/// </summary>
public class UEnumPopupBase : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GUIStyle _style = GUIStyle.none;

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
    protected UEnumPopupBase()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UEnumPopupBase(GUIStyle style)
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
            EditorGUI.BeginChangeCheck();
            {
                if (string.IsNullOrEmpty(_caption))
                {
                    _enum = EditorGUILayout.EnumPopup(_enum, _style);
                }
                else
                {
                    _enum = EditorGUILayout.EnumPopup(_caption, _enum, _style);
                }
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
