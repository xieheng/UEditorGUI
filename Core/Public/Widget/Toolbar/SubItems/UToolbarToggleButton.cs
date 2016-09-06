using UnityEngine;
using UnityEditor;

public class UToolbarToggleButton : UToggleButton
{
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toggled"></param>
    public UToolbarToggleButton(bool toggled = false)
        : base("Toggle Button", EditorStyles.toolbarButton)
    {
        _toggled = toggled;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="toggled"></param>
    public UToolbarToggleButton(string caption, bool toggled = false)
        : base(caption, EditorStyles.toolbarButton)
    {
        _toggled = toggled;
    }

    #endregion
}
