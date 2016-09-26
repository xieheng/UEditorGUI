using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
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
            EditorGUILayout.HelpBox(_text, _type);
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public string text
        {
            set { _text = value; }
            get { return _text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MessageType messageType
        {
            set { _type = value; }
            get { return _type; }
        }

        #endregion
    }
}