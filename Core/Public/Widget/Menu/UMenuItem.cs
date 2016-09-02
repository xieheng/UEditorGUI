using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public abstract class UMenuItem : UControl
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected GenericMenu _parent = null;

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    public void SetParent(GenericMenu parent)
    {
        _parent = parent;
    }

    #endregion
}

/// <summary>
/// 
/// </summary>
public class UMenuButton : UMenuItem
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _text = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    private bool _enabled = true;

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
    /// <param name="text"></param>
    public UMenuButton(string text)
    {
        _text = text;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (_parent == null)
            return;

        if (_enabled)
        {
            _parent.AddItem(new GUIContent(_text), false, OnClickedHandler);
        }
        else
        {
            _parent.AddDisabledItem(new GUIContent(_text));
        }
    }

    #endregion

    #region Public

    /// <summary>
    /// 
    /// </summary>
    public bool IsEnabled
    {
        set { _enabled = value; }
        get { return _enabled; }
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
            UEventArgs args = new UEventArgs();
            OnClicked(args);
        }
    }

    #endregion
}

/// <summary>
/// 
/// </summary>
public class UMenuSeparator : UMenuItem
{
    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (_parent != null)
        {
            _parent.AddSeparator(string.Empty);
        }
    }

    #endregion
}
