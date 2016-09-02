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
    private UToolbar _toolbar = new UToolbar();

    /// <summary>
    /// 
    /// </summary>
    private ULayout _layout = new UVLayout();

    #endregion

    #region Event
    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public string Caption
    {
        set { title = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public UToolbar Toolbar
    {
        get { return _toolbar; }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    protected UWindow()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnGUI()
    {
        _toolbar.OnGUI();
        _layout.OnGUI();

        Repaint();
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnFocus()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void OnLostFocus()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {

    }

    #endregion

    #region Static

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static void ShowWindow<T>() where T : UWindow
    {
        UWindow win = EditorWindow.GetWindow<T>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static void ShowWindow<T>(string caption) where T : UWindow
    {
        UWindow win = EditorWindow.GetWindow<T>();
        win.title = caption;
    }

    #endregion
}
