using UnityEngine;
using UnityEditor;

public class UIntPopup : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected int _value = 0;

    /// <summary>
    /// 
    /// </summary>
    protected int[] _values = null;

    /// <summary>
    /// 
    /// </summary>
    protected string[] _texts = null;

    #endregion

    #region Event

    /// <summary>
    /// 
    /// </summary>
    public event UIntChangedEventHandler OnValueChanged;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    public UIntPopup(int initValue, int[] values, string[] texts)
    {
        _value = initValue;
        _values = values;
        _texts = texts;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    public UIntPopup(string caption, int initValue, int[] values, string[] texts)
    {
        _caption = caption;
        _value = initValue;
        _values = values;
        _texts = texts;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    /// <param name="style"></param>
    protected UIntPopup(int initValue, int[] values, string[] texts, GUIStyle style)
    {
        _value = initValue;
        _values = values;
        _texts = texts;
        _style = style;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="initValue"></param>
    /// <param name="values"></param>
    /// <param name="texts"></param>
    /// <param name="style"></param>
    protected UIntPopup(string caption, int initValue, int[] values, string[] texts, GUIStyle style)
    {
        _caption = caption;
        _value = initValue;
        _values = values;
        _texts = texts;
        _style = style;
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI()
    {
        if (!_visible)
            return;

        GUI.color = _color;
        {
            EditorGUI.BeginChangeCheck();
            {
                _value = EditorGUILayout.IntPopup(_caption, _value, _texts, _values);
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
            UIntEventArgs args = new UIntEventArgs(this, _value);
            OnValueChanged(args);
        }
    }

    #endregion
}
