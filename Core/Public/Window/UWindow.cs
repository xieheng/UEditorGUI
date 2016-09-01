using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UWindow : EditorWindow
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private ULayout _layout = new UVLayout();

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnGUI()
    {
        _layout.OnGUI();
        Repaint();
    }

    #endregion
}
