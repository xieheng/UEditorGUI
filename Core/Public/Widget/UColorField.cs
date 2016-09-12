using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UColorField : UWidget
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
    {
        _caption = caption;
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
    {
        _caption = caption;
        _value = color;
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
            EditorGUI.BeginChangeCheck();
            {
                _value = EditorGUILayout.ColorField(_caption, _value);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnColorChangedHandler();
            }
        }
        GUI.color = Color.white;
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
