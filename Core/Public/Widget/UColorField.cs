using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UColorField : UCaptionWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected Color _value = Color.white;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UColorChangedEventHandler OnColorChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UColorField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UColorField(string caption)
        : base(caption)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bounds"></param>
    public UColorField(Color color)
    {
        _value = color;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="bounds"></param>
    public UColorField(string caption, Color color)
        : base(caption)
    {
        _value = color;
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
            _value = EditorGUILayout.ColorField(caption, _value);
        }
        bool changed = EditorGUI.EndChangeCheck();

        if (changed)
        {
            OnColorChangedHandler();
        }
    }

    #endregion

    #region Private

    /// <summary>
    /// 
    /// </summary>
    private void OnColorChangedHandler()
    {
        if (OnColorChanged != null)
        {
            UColorEventArgs args = new UColorEventArgs(this, _value);
            OnColorChanged(args);
        }
    }

    #endregion
}
