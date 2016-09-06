using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToggleButton : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected bool _toggled = false;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UToggleChangedEventHandler OnToggleChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UToggleButton()
    {
        _caption = "Toggle Button";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToggleButton(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UToggleButton(string caption, GUIStyle style)
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
            Rect rect = GUILayoutUtility.GetRect(new GUIContent(_caption), _style, GUILayout.ExpandWidth(false));

            EditorGUI.BeginChangeCheck();
            {
                _toggled = GUI.Toggle(rect, _toggled, string.Empty, _style);
            }
            bool changed = EditorGUI.EndChangeCheck();

            GUIStyle labelStyle = EditorStyles.miniLabel;
            labelStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Label(rect, _caption, labelStyle);

            if (changed)
            {
                OnToggleChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public bool IsToogled
    {
        set 
        {
            bool store = _toggled;
            _toggled = value; 

            if (store != _toggled)
            {
                OnToggleChangedHandler();
            }
        }
        get { return _toggled; }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnToggleChangedHandler()
    {
        if (OnToggleChanged != null)
        {
            UToggleEventArgs args = new UToggleEventArgs(this, _toggled);
            OnToggleChanged(args);
        }
    }

    #endregion
}
