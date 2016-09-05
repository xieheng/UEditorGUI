using UnityEngine;
using UnityEditor;

public class UButtonBase : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GUIStyle _style = GUIStyle.none;

    #endregion

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
    protected UButtonBase()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="style"></param>
    protected UButtonBase(GUIStyle style)
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
            if (GUILayout.Button(_caption, _style))
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
