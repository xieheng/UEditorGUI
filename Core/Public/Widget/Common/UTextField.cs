using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UTextField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected string _text = string.Empty;
    
    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UTextChangedEventHandler OnTextChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UTextField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UTextField(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UTextField(GUIStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UTextField(string caption, GUIStyle style)
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
                if (string.IsNullOrEmpty(_caption))
                {
                    _text = EditorGUILayout.TextField(_text, _style);
                }
                else
                {
                    _text = EditorGUILayout.TextField(_caption, _text, _style);
                }
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnTextChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnTextChangedHandler()
    {
        if (OnTextChanged != null)
        {
            UTextEventArgs args = new UTextEventArgs(this, _text);
            OnTextChanged(args);
        }
    }

    #endregion
}
