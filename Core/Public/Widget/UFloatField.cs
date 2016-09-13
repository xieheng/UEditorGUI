using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UFloatField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private float _value = 0f;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UFloatChangedEventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public UFloatField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UFloatField(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public UFloatField(float value)
    {
        _value = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="value"></param>
    public UFloatField(string caption, float value)
    {
        _caption = caption;
        _value = value;
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
                _value = EditorGUILayout.FloatField(_caption, _value);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnValueChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private 

    /// <summary>
    /// 
    /// </summary>
    private void OnValueChangedHandler()
    {
        if (OnValueChanged != null)
        {
            UFloatEventArgs args = new UFloatEventArgs(this, _value);
            OnValueChanged(args);
        }
    }

    #endregion
}
