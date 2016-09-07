using UnityEngine;
using UnityEditor;

public class UButton: UWidget
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
        _caption = "Button";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UButton(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="style"></param>
    protected UButton(string caption, GUIStyle style)
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
            bool clicked = false;

            if (_style == GUIStyle.none)
            {
                clicked = GUILayout.Button(_caption);
            }
            else
            {
                clicked = GUILayout.Button(_caption, _style);
            }

            if (clicked)
            {
                OnClickedHandler();
            }
        }
        GUI.color = Color.white;
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
