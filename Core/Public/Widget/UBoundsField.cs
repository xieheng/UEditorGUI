using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UBoundsField : UCaptionWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected Bounds _bounds = new Bounds();

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UBoundsChangedEventHandler OnBoundsChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UBoundsField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UBoundsField(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bounds"></param>
    public UBoundsField(Bounds bounds)
    {
        _bounds = bounds;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="bounds"></param>
    public UBoundsField(string caption, Bounds bounds)
        : base(caption)
    {
        _bounds = bounds;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    protected override void UpdateGUI()
    {
        EditorGUI.BeginChangeCheck();
        {
            _bounds = EditorGUILayout.BoundsField(caption, _bounds);
        }
        bool changed = EditorGUI.EndChangeCheck();

        if (changed)
        {
            OnBoundsChangedHandler();
        }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void OnBoundsChangedHandler()
    {
        if (OnBoundsChanged != null)
        {
            UBoundsEventArgs args = new UBoundsEventArgs(this, _bounds);
            OnBoundsChanged(args);
        }
    }

    #endregion
}
