using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UToggleButton : UCaptionWidget
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
        caption = "Toggle Button";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UToggleButton(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UToggleButton(string caption, GUIStyle style)
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
        Rect rect = GUILayoutUtility.GetRect(new GUIContent(caption), style, GUILayout.ExpandWidth(false));

        EditorGUI.BeginChangeCheck();
        {
            _toggled = GUI.Toggle(rect, _toggled, string.Empty, style);
        }
        bool changed = EditorGUI.EndChangeCheck();

        GUIStyle labelStyle = EditorStyles.miniLabel;
        labelStyle.alignment = TextAnchor.MiddleCenter;

        GUI.Label(rect, caption, labelStyle);

        if (changed)
        {
            OnToggleChangedHandler();
        }
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public bool toggled
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
