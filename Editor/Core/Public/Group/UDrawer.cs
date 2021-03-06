﻿using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UDrawer : UControlArea
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private bool _foldout = true;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UDrawer(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="foldout"></param>
        public UDrawer(string caption, bool foldout)
            : base(caption)
        {
            _foldout = foldout;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            string title = _foldout ? "\u25BC " + caption : "\u25B2 " + caption;

            if (!_foldout)
            {
                GUI.backgroundColor = Color.white * 0.8f;
            }

            if (!GUILayout.Toggle(true, title, "DragTab"))
            {
                _foldout = !_foldout;
            }
            GUI.backgroundColor = Color.white;

            if (_foldout)
            {
#if UNITY_4_7
                EditorGUILayout.BeginVertical("As TextArea", GUILayout.MinHeight(10));
#elif UNITY_5
                EditorGUILayout.BeginVertical("As TextArea", GUILayout.MinHeight(10));
#elif UNITY_2017
                EditorGUILayout.BeginVertical("TextArea", GUILayout.MinHeight(10));
#endif
                {
                    DrawControls();
                }
                EditorGUILayout.EndVertical();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public bool foldout
        {
            set { _foldout = value; }
            get { return _foldout; }
        }

        #endregion
    }
}