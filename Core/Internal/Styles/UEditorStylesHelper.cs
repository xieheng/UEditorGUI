﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UEditorGUI.Internal.Styles
{
    /// <summary>
    /// 
    /// </summary>
    internal class UEditorStylesHelper
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, GUIStyle> styleMap = new Dictionary<string, GUIStyle>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Texture2D> iconMap = new Dictionary<string, Texture2D>();

        #endregion

        #region Instance

        /// <summary>
        /// 
        /// </summary>
        private  static UEditorStylesHelper _instance = null;

        /// <summary>
        /// 
        /// </summary>
        private static UEditorStylesHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UEditorStylesHelper();
                    _instance.Load();
                }

                return _instance;
            }
        }

        #endregion

        #region Public 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GUIStyle GetStyle(string name)
        {
            return Instance.styleMap[name];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Texture2D GetIcon(string name)
        {
            return Instance.iconMap[name];
        }

        #endregion

        #region Private 

        /// <summary>
        /// 
        /// </summary>
        private void Load()
        {
            UEditorStyles styles = AssetDatabase.LoadAssetAtPath("Assets/Editor/UEditorGUI/Core/Internal/Styles/UEditorStyles.asset", typeof(UEditorStyles)) as UEditorStyles;

            if (styles == null)
            {
                Debug.LogError("Load styles of editor gui failed");
                return;
            }

            foreach (GUIStyle style in styles.styles)
            {
                styleMap.Add(style.name, style);
            }

            foreach (Texture2D icon in styles.icons)
            {
                iconMap.Add(icon.name, icon);
            }
        }

        #endregion
    }
}