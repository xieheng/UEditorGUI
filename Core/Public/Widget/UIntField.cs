using UnityEngine;
using UnityEditor;

public class UIntField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected int _value = 0;

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
    public UIntField()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    public UIntField(string caption)
    {
        _caption = caption;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initValue"></param>
    public UIntField(int initValue)
    {
        _value = initValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="initValue"></param>
    public UIntField(string caption, int initValue)
    {
        _caption = caption;
        _value = initValue;
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
                _value = EditorGUILayout.IntField(_caption, _value);
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
