using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class UHelpBox : UWidget
{
    #region Data

    /// <summary>
    /// 
    /// </summary>
    private string _text = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    private MessageType _type = MessageType.None;

    #endregion

    #region Construction

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="type"></param>
    public UHelpBox(string message, MessageType type)
    {
        _text = message;
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
            EditorGUILayout.HelpBox(_text, _type);
        }
        GUI.color = Color.white;
    }

    #endregion
}
