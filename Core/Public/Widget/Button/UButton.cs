using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UButton : UWidget
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

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        GUI.color = _color;
        {
            if (GUILayout.Button(_caption))
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
    private void OnClickedHandler()
    {
        if (OnClicked != null)
        {
            UEventArgs args = new UEventArgs(this);
            OnClicked(args);
        }
    }

    #endregion
}
