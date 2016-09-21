using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UButton : UCaptionWidget
{
    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UEventHandler OnClicked;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UButton()
    {
        caption = "Button";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UButton(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UButton(string caption, GUIStyle style)
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
        bool clicked = false;

        if (style == GUIStyle.none)
        {
            clicked = GUILayout.Button(caption);
        }
        else
        {
            clicked = GUILayout.Button(caption, style);
        }

        if (clicked)
        {
            OnClickedHandler();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void ActiveToolbarGuiStyle()
    {
        this.style = EditorStyles.toolbarButton;
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnClickedHandler()
    {
        if (OnClicked != null)
        {
            UEventArgs args = new UEventArgs(this);
            OnClicked(args);
        }
    }

    #endregion
}
