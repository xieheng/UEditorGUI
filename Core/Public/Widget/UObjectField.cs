using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UObjectField : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    protected Object _object = null;

    /// <summary>
    /// 
    /// </summary>
    protected System.Type _type = null; 

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public UObjectField(System.Type type)
    {
        _type = type;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="caption"></param>
    /// <param name="type"></param>
    public UObjectField(string caption, System.Type type)
    {
        _caption = caption;
        _type = type;
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
                _object = EditorGUILayout.ObjectField(_caption, _object, _type);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnObjectChangedHandler();
            }
        }
        GUI.color = Color.white;
    }

    #endregion

    #region Private 

    /// <summary>
    /// 
    /// </summary>
    private void OnObjectChangedHandler()
    {

    }

    #endregion
}
